# Amazon Block Storage
###### 22<sup>nd</sup> March 2026 - Puneet Gavri

In this section we will look at AWS Block Storage options. Data is divided into small chunks and stored in a disk abstract to us. We primarily have two types of Block Storages.

1.  [**Instance Storage**](#instance-storage)
    * [Key Features of Instance Storage](#key-features-of-instance-storage)
2.  [**EBS - Elastic Block Storage**](#ebs---elastic-block-storage)
    * [Key Features of EBS](#key-features-of-ebs)
    * [Commands to Mount EBS](#commands-to-mount-ebs)
    * [EBS Snapshots](#ebs-snapshots)
    * [EBS Performance Metrics](#ebs-performance-metrics)
    * [EBS Volume Types](#ebs-volume-types)

## Instance Storage
AWS Instance storage provides temporary, high-performance block-level storage for EC2 instances, physically attached to the host computer.

### Key Features of Instance Storage
1. It is physically attached to the physical server from where the VM is created (virtualized). 
2. It is not available in all instance types e.g. c5d.large comes with 100GB instance storage. We cannot change the size.
3. These are Ephemeral which means data stored here gets lost when the instance is restarted (new VM may come from another physical server).
4. These are high-performant as they are on the same physical server.
5. **It is perfect for cache, buffer, scratch data, high-performance processing where data loss is ok**. 

## EBS - Elastic Block Storage
Amazon **EBS** Elastic Block Store is a high-performance, block-level storage service, designed for use with Amazon EC2 instances. It provides **persistent, durable, and scalable** storage volumes that can be attached to instances, allowing them to act as formatted, raw block devices (similar to a physical hard drive)  
Data is divided into small chunks (blocks) and stored in disk (which is abstract to us)

### Key Features of EBS
1. **Persistent Data** : Data remains available even after EC2 instances are stopped or terminated (except for root volume).
2. **High Availability** :  Volumes are automatically replicated within an Availability Zone to protect against component failures, ensuring high durability.
3. **Scalability** : We can scale the capacity UP as needed.
4. **Snapshots** : Point-in-time backup can be created, which can be used to disaster recovery or move the data from one AZ to another.
5. **Encryption** :  Data at rest, as well as data in transit between volumes and instances, can be encrypted using AWS KMS

### Notes
1. **EBS** are outside storage, they don't come from the same physical server (as Instance Storage)
2. **Root** volume is also an EBS. This is where OS is stored.
3. We can attach EBS storage to only one EC2 at a time, some exceptions apply, such as
    1. EBS is of type Multi Attach
    2. EC2 instance is of a specific type (Nitro)
4. We can attach more than one EBS volume to an Instance
5. Each EBS, when attached to an instance, gets shown in as volume in Block Devices, these must be mounted on the EC2 instance after being attached in order to be used.
6. EBS size can only be **increased**. Size range is 1GB to 64 TB 
7. EBS is a **Zonal Service**, so it can only be attached to an EC2 instance on the same Availability Zone
8. Freshly created EBS DOES NOT have a file system (as it is raw volume), we must create a file system on it. 
9. We pay for the booked storage size of the EBS, not as per the usage. e.g. we will pay for full size of the EBS, even when it is empty.

### Commands to mount EBS
``` linux
lsblk -f #this command will list all block drives (drives)
sudo mkfs -t xfs /dev/nvme1n1
df -h #this shows volumes and some info (only the ones which are mounted). This does not show our new EBS (in both cases when raw or even after adding mkfs). So we need to first mount it.
sudo mkdir /data #create a directory on root ebs where we will mount this.
sudo mount /dev/nvme1n1 /data
df -h #now this will show info about our new volume.
edit /etc/fstab to add mount information (so that when we restart, we do not loose mount)
```

#### Summary
Additionally attached volumes can only be used after we create filesystem on volume and mount it on our EC2 instance. We should also update the fstab so that the newly mounted storage can be persisted. 

#### Question 
In read world, we may have app deployed to multiple regions (may also be in multi AZ within a region). We will need to attach a persistent storage to EC2 instance across regions? but EBS wont allow that. How would we solve this problem ?  
**Answer** : Solution is **EFS and S3**. We will see that in future sessions

### EBS Snapshots
We can take backups of our EBS volumes for data recovery or for compliance purposes.  
Every time a create a backup of an EBS volume, a new **Snapshot** gets generated. These Snapshots are **incremental** in nature which means
1. When we create a new Snapshot, we only keep changes from previous snapshot. 
2. When we delete a Snapshot, data gets cascaded to the next snapshot in the chain (so we can safely delete the older snapshots as needed)

We can schedule periodic backups for our EBS volumes. 

#### [How AWS Snapshots Work](https://docs.aws.amazon.com/ebs/latest/userguide/how_snapshots_work.html)

#### Note 
**EBS Snapshots** and **Custom AMI** are stored in **Amazon S3**.

### EBS Performance Metrics
We can measure performance of a storage using below metrics
1. **Throughput** - How much data can go in and come out of the storage per seconds, measured in MB/S. We need high throughput when the application desires, low number of operations per second but high volume data processing. 
2. **IOPS** - How many operations (inbound and outbound) are possible in per second. 12000 iops means 1200- threads / operations can be performed per second. We need high iops when we want to handle small data size but large number of operations per second e.g. eCommerce app?

### EBS Volume Types
Based on this, we can choose the type of the volume. 
1. **SSD** - configured for high iops. Use this for frequent read and writes. Root volumes are always SSD
2. **HDD** - better at throughput.  

**EBS Volume Types** : https://docs.aws.amazon.com/ebs/latest/userguide/ebs-volume-types.html


