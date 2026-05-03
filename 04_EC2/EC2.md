# EC2 Service
###### 14<sup>th</sup> March 2026 - Puneet Gavri

Amazon Elastic Compute Cloud (EC2) is a core web service from AWS that provides computing capacity in the cloud. It allows you to rent virtual servers, known as instances, to run applications without needing to invest in physical hardware upfront.

* [EC2 Instance Core Components](#ec2-instance-core-components)
    * [Name and Tag](#name-and-tag)
    * [AMI (Amazon Machine Image)](#ami-amazon-machine-image)
    * [Instance Type](#instance-type)
    * [Key Pair](#key-pair)
    * [Network](#network)
    * [Storage](#storage)
    * [Advanced Details and User Data](#advanced-details)
* [EC2 Custom Image](#ec2-custom-image)

## EC2 Instance Core Components 

### Name and Tag
When creating an EC2 instance we can provide a meaningful name to it so that it can be easily distinguished from other EC2 instances.  
We can also tag multiple instances to a common value which can be used to 
1. Manage Access
2. Track Costs, etc

### AMI (Amazon Machine Image)
This is where we choose the OS for the EC2 instance. We can choose from a range of Operating Systems and their versions such as
1. Amazon Linux 
2. Ubuntu
3. RedHat 
4. Windows
5. MacOS 

We can also create an our own image with pre installed softwares and pre stored files and spin up EC2 instance from out custom image.

### Instance Type
This is where we choose the size of the EC2 instance (RAM, CPU and Storage)  
We have following instance families 
1. General Purpose (T, M, A)
2. Compute Optimized (C)
3. Memory Optimized (R, X, U)
4. Storage Optimized (I, D, H)
5. Accelerated Computing (P, G, Inf)

Each Instance Type contains family, generation and then size. e.g. 
1. t3.micro - General Purpose, 3rd generation, micro instance type
2. t3.xlarge -  General Purpose, 3rd generation, extra large instance type

### Key Pair
This is to be defined if we want to SSH into our Machine. Must be supplied while creation. 
Notes 
1. We cannot modify this once an EC2 instance is created. 
2. We can use same Key Pair for multiple EC2 instances. 
3. AWS maintains Key Pair per region. 
4. AWS stores public key of the Key pair in the EC2 instance (specifically in the ~/.ssh/authorized_keys file for Linux). We can download the private key on the machine from where we want SSH into the EC2 instance. 

### Network
We can choose following Networking components under which our EC2 instance will be created 
1. **Virtual Private Cloud (VPC)** - This is a Virtual Network on the Cloud
2. **Subnet** - This is part of the Virtual Network (may be Public i.e. Internet connected or Private i.e not connected to Internet)
3. **Security Group** - This is a Firewall on the EC2 instance that maintains the inbound and outbound rules, basically defining which kind of traffic is allowed to and fro from the EC2 instance. e.g allow SSH traffic from anywhere or select list of IPs of select Subnets, etc. This defines, which protocol, Port Number and IP range is allowed. 

**Protocola sna Default Ports**  
1. SSH is a protocol that allows us to connect to a Linux and Mac machine. Its 2. RDP protocol allows us to remote into a Windows machine
3. HTTP Protocol is used to send Web Request 
4. Default Ports for some of these Protocols
    1. HTTP 80
    2. HTTPS 443
    3. SSH - 22
### Storage
Storage is means to store and access data via the EC2 instance. We have three types of Storage associated with EC2 instance 
1. **EBS** (Elastic Block Storage) - This is the Hard-disk that the EC2 instance comes with. Each Instance comes with one virtual disk which is called Root Volume. Some points to note are  
    1. AMI / OS is also installed in this root volume.
    2. We can attach additional volume to the EC2 instance if needed
    3. Data is retained on these storages even after we restart the EC2 instances (similar to how files created on out PC is retained even after rebooting)
    4. These storage are backed by SSD while the additional EBS volumes that we can attach can be SSD or HDD - based on our use-case.
    5. An EBS can only be attached to one EC2 instance at a time (some exceptions apply)
2. **EFS** (Elastic file Storage) - This is like a Shared File System, hosted outside the EC2 instance which can be used by multiple EC2 instances.
3. **S3** (Simple storage Service) - This is to be populated later

### Advanced Details
This is where we can setup additional advanced configurations such as
1. DNS Host Name
2. IAM - Identity Access Management
3. Instance Auto Recovery (Default or Disabled)
4. Instance Shutdown Behavior (Stop or Terminate)
5. Stop - Hibernate behavior (Enable / Disable)
6. Termination Protection (Enable / Disable)
7. Stop Protection (Enable / Disable)
8. Detailed CloudWatch Monitoring (Enable / Disable)
9. EBS-Optimized Instance (Enable / Disable)
10. Purchasing Options
    1. None
    2. Spot Instances
    3. Capacity Reservations
    4. Tenancy (Shared, Dedicated)
11. User Data - This is bash script that runs when the EC2 instance is first created, we can use this to run updates and install needed software packages needed by our application.


## EC2 Instance IP Addresses
When an instance is created, 
* Public IP gets assigned to it by default (unless specified). This Public IP is randomly assigned from an AWS pool of Public IPs   
* Private IP gets assigned to it.  

**Public IP** 
1. Is used for Internet traffic (HTTP / SSH, etc). 
2. This is optional, resources that do not need to be Internet facing DO NOT need a public IP e.g. DB, Cache, etc. 
3. This is unique across the globe and hence it is expensive. 
4. When we stop an instance, the Public IP is released back to AWS pool. When we start the EC2 instance, we will see a new Public IP assigned to it.
5. When restarting the Public IP is retained (as AWS knows restart does not take too much time so it does not release the Public IP back to the pool)
6. We can assign a static Public IP to an EC2 instance (if needed) so that the instance will always have the same public IP. We can purchase Public IPs from AWS or over the internet.
7. Cost of Public IP is 0.005 USD per hour.

**Private IP**
1. used for internal AWS Internet traffic
2. This does not change once it is assigned to the EC2 instance
3. This is assigned from one of the available IP addresses from the Subnet's network range (CIDR)
4. This is free

## How to connect to an EC2 instance?
We have a few ways to connect to EC2 instance, but we must first setup the EC2 instance to allow to accept the connection. To do so, we need to do the following
1. Enable SSH traffic coming into the EC2 instance via the Security Group from the IP address from where we want to connect to EC2 instance.
2. Assign Ec2 instance a Key-Pair while creation.

### Connect via AWS Console. 
1. Choose the Instance to connect and follow the instructions to connect 

### Connect via SSH Client
1. Store Key Pair on the system 
2. Grant read access to the key pair (chmod 400)
3. use ssh command. We can use putty if we cannot run ssh command for some reason (like we are connecting fro Windows 10 or lower version)

## EC2 Custom Image
We can create an image (AMI) from an a running EC2 instance which can be then used to create other EC2 instances.  
This is very useful in cases where we need to replicate a same type of EC2 instance multiple times e.g. auto scaling when load increases.  
### Notes
1. Custom AMI's get created in the same region as the EC2. We can transfer it to other regions if we want to create the EC2 instances in other regions. 
2. Root volume is part of the custom image, this is how the OS and other files on the root volume will remain identical on the new EC2 instance created from the custom image.

### How to create Custom Image?
Select Instance --> Actions -->  Image and templates --> Create image

## EC2 Purchasing Options	
Purchasing Options
		On Demand (what we do)
		Savings Plan (pre planned) e.g. commitment to consistent amount of usage USD per hour.
		Reserved -- Committed EC2 instance for a fixed period of time.
		Spot instances - Unused EC2 instance (90% discount).. place bidding. These can be taken away anytime (if it goes into demand)
		Dedicated Hosts (compliance, where a company wants a dedicated server where only their EC2 insatnces will be hosted. This will be discounted. So think of this as single tenant Physical Server, assigned to the tenant. You pay for the complete host, even if we do not use fully. E.g. Physical server may have camacity to host 1000 t3.micro but we have only 10, we still pay for all 1000). Note, generally, EC2 instances are are multi tenanted, when we ask for EC2 instance, we get an EC2 instance on some server from the AZ in the region. there will be other EC2 instances on the samy physical server.
		Dedicated Instances
		Capacity Reservation -- E.g we want 10 t2.medium instances in mumbai 1a. We may have availability now but not always. So we can use capacity reservation but what if the
		
		Note -- When we create an EC2 instance, we can choose Payment Options in the Advanced section (including spot instances). Note to self, go through all advanced options.
		
	Payment Options
		All Upfront
		Partial Upfront
		No Upfront
		
	Placement Groups (Decides where the EC2 instance is placed)
		Cluster (placed close to each other, faster to connect form one another)
		Partition (within AZ, separate rack)
		Spread (EC2 in different Physical Servers)
		
	Choose Instance --> Actions --> Monitor and Trouble shoot (logs while system was being created, shutting down, booting up, etc)
	Next Session -- IAM *** VERY IMP