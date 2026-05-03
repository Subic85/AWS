# AWS File Storage
###### 29<sup>th</sup> March 2026 - Puneet Gavri

* [Why File Storage?](#why-file-storage)
* [Key Features of File Storage ](#key-features-of-file-storage)
* [Storage Class](#storage-class)
* [EFS Performance](#efs-performance)
* [Mount Target](#mount-target)
* [EFS Regional Architecture](#efs-regional-architecture-diagram)
* [Options While Creating EFS](#options-while-creating-efs)
* [FSX](#fsx)


## Why File Storage?
As we saw in the previous section that EBS can only be used with a single EC2 instance (exceptions apply). Also, this can only be used within the AZ its created.  
What to do when we want to have a shared file storage across multiple EC2 instances across Availability Zones within a region? We use **AWS File Storage**

## Key Features of File Storage
1. **Elastic Scalability** - File system grows and shrinks automatically, eliminating the need to pre-provision storage. 
2. **High Performance and Low Latency** - Designed for high-performance computing (HPC) and parallel processing
3. **Fully Managed & Cost-Effective** - AWS handles maintenance, backups, and security, reducing management overhead and allowing for pay-as-you-go pricing
4. **Shared Access** - Offers shared, concurrent access for thousands of EC2 instances and on-premises servers
5. **Security and Compliance** - Provides robust security, including data encryption, access control (IAM).
6. We only pay for usage, no concept of provisioned capacity.

## Storage Class
AWS provides multiple Storage Classes which define how the data is stored and maintained within AWS. Based on the Storage Class, the charges change and so does the latency while reading the file  
https://docs.aws.amazon.com/efs/latest/ug/features.html

| |EFS Standard | EFS Infrequent Access | EFS Archive |
| --- | --- | --- | --- |
| Use-case | Active, high-performance | Inactive, infrequently accessed | Cold/Archive data |
| Uses | Uses SSD for high performance | uses lower-cost storage with higher latency and retrieval fees| uses lower-cost storage with higher latency and retrieval fees |
| Cost | Standard Baseline Charge | It is up to 95% cheaper than Standard for storage, but incurs fees when files are | It offers up to 50% lower costs than IA but has higher access fees |
| Latency |Sub-millisecond | Tens of milliseconds| Tens of milliseconds |
| Min. Storage |N/A (Configurable) | N/A (Configurable)| 90 Days |
| Lifecycle Management | Transition to Standard: Moves files back to Standard upon access <br> New and modified files go here directly|Transition to IA : Default is 30 days since last access| Transition to Archive: Default is 90 days since last access.

## EFS Performance
https://docs.aws.amazon.com/efs/latest/ug/performance.html

We can choose what kind of performance we want from the storage. It relates to Latency, IOPS and Throughput. We have following options
1. **Elastic** (AWS Recommended)
    1. Throughput changes based on the volume of data being accessed
2. **Provisioned IOPS**
    1. Fixed IOPS
3. **Bursting** 
    1. Throughput changes based on the Size of data being stored on EFS.

### Note
1. EFS read speed is approx 1 millisecond
2. EFS write speed is approx 3 millisecond

## Mount Target
An AWS Mount Target is a network endpoint in a specific VPC subnet that allows Amazon EC2 instances and other resources to access an Amazon Elastic File System (EFS)

### Key Functions of Mount Target
1. **Network Interface** - When you create a mount target, AWS creates a network interface (ENI) in the specified subnet with a private IP address
2. **Connectivity** -  It acts as the gateway through which NFS clients  connect to the file system using that IP address or its DNS name
3. **Regional Reach** - To access an EFS file system from instances in different Availability Zones, you should create one mount target in each AZ

### Requirement of a Mount Point
1. **Subnet Specificity** - Each mount target is tied to one specific subnet.
2. **Single Target per AZ** - You can only create one mount target per Availability Zone for a specific EFS file system
3. **Security Groups** - Mount targets use security groups to control inbound and outbound traffic, typically requiring port 2049 (NFS) to be open for your EC2 instances.

### Summary
Lets say we have 3 AZs in our region. e.g. ap-south (1a, 1b, 1c)  
If we want to use our EFS from instances across all AZs, we will need to
1. Create a network (VPC) that spans across all AZs within the region
2. Then we need to have end points (Mount Target) in each AZ (exactly 1). 
3. Then we can use this enpoint, to point to our EC2 instances in all AZs.

### Notes 
1. Mount target get an IP Address (assigned from within the Subnet's CIDR range).
2. Mount target will also have a Security Group.
3. We need to mount EFS on our EC2 instance, this is similar to mounting the EBS Storage. Additionally, we need to install EFS client on each EC2 instance where we want to use it
4. EC2 instance Security Group should allow traffic from the Mount Target's Security Group

### EFS Regional Architecture Diagram
![EFSRegionalArchitecture](images/EFSRegionalDiagram.svg)


## Options While creating EFS
1. Network - Here we need to choose in which VPS our EFS will be created
2. Regional or AZ Specific - Choose AZ if we want to use it from Single AZ, this runs risk of unavailability if our AZ is down
3. Auto backup - AWS Backup Service is used internally to create auto backups
4. LifeCycle Management - This is where we can configure, how files will be moved from one Storage Class to the Other
5. Encryption - We can encrypt the files at rest by using Keys from AWS Key Management Service
6. Performance - HEre we can choose what kind of performance we want, such as Elastic, Bursting  or Provisioned.
7. Mount Target - Here we need to Setup Mount Target for each AZ where we want to use our EFS. 
8. File System Policy
    1. Prevent Anonymous Access 
    2. Enforce Read-only
    3. Prevent Root Access

## Demo Steps
1. Create EFS
2. Setup Mount Target
3. Create two EC2 instances in each AZ (6 total)
4. Allow traffic from EC2 instances to Mount Target (configure Security Groups to allow NFS from Mount Target's EC2)
5. Perform these steps in all EC2 instance (we can use User Data)
    1. Install EFS Client
    2. Create Directory for EFS Mounting
    3. Mount EFS
    4. Check Volumes
    5. Create file on EFS frm any one EC2, we should we able to access this from other EC2 instances. 

## FSX
EFS CANNOT be mounted on EC2 instances with Windows OS so we use FSX for those.

### FSX Features
1. Can be used with WIndows as well as Linux
2. Very High Performant (high IOPS and Throughput)
3. Expensive.
4. Good for Machine Learning use-case 
5. Additionally, we have **FSX Luster** which is only for Linux. This is even faster than regular FSZ, provides millions of IOPS.