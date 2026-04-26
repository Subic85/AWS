AWS

Puneet Gavri - https://github.com/puneetgavri
14th March -- Puneet Gavri

Refresh Cloud Basics

Problem Before Cloud
	
	Capex - business owner would need to buy the following to host website
		Server
		Storages
		Network equipment like routeer/ switches
		rent place to keep this stuff
		electricity (Cooling)
		OS
		Maintenance 
		Tech Experts 
		Security (Virus)
		Licences etc
	
		So lot of Capex to begin with and imagine business not doing well, all this is a waste 
	
	Platform Dependnecy
		Another problem, once you buy the physical server, we need to install OS and then on top, we can deploy apps. If OS is windows, i can only deploy Windows APPS (cant deploy non windows)
		
		We could solve this by adding a Hyper V and then creating multiple Virtual machine each having its own OS. These are completely isolated.
		
		HyperV may or may not need an OS. There are versions of HyperV that directly go on Bare-Metal.
		
	Now when this Physical Hardware is exposed to other people over the internet to create and use VMs is Cloud Computing. These VMs can be rented on the pay-as-you-go model. If needed, we can also ask for higher RAM, CPU at specific times of the day. Why pay more throughout.
	
	
Service Models
	IaaS -- Infrastructure as a Service
		rent - Servers, Storages, Network, Data Centers, Virtualization.
		Here above mentioned items are abstract to use. We can though choose, what DB to use, what OS to use, what security to use and our own app.
		
	Paas -- Platform as a Service
		PaaS = IaaS + some more. More = we only care about the App. but OS and DB, etc are not in our control?
		
	SaaS -- Software as a Service
		Everythng is managed by them. e.g. Gmail, YahooMail, GoogleMaps, GoogleDocs
		
	In SaaS, all of below is managed by cloud provider.
	In PaaS -- App is managed by us and rest by cloud
	In SaaS -- App, Security, DB and OS are managed by us, rest by Clould Provider.
	App -- 
	Security
	DB
	OS
	VirtualizationStorage
	Network
	Server
	DataCenters
	
	OnPrem -- this is not clould, we manage everything on our own.
	
	
	
Region Vs Availability Zone V Vs Data Center Vs EdgeLocation
	Discussed in Intro
	
North Virginia is the most popular region, most new Services are first available there.


Services -- can be used to create resources.
	e.g. EC2 is a service that can be used to create an EC2 instance (resource)
	Some services are regional and some are global. E.g. IAM is global. EC2 instance is Regional (as these are created on a specific region). How should we choose regions, following considerations
		1. Closer to the majority user base
		2. Business Compliance (bank may want to keep all data in host country)
		3. Governing law (country specific law)

	EC2
		Elastic Compute Cloud
		EC2 is a service that can be used to create an EC2 instance (resource), EBS (resource)
		Cost is calculated by minutes
		Launch EC2 -- provide following
			1. Name
			2. AMI (Amazon Machine Image)-- Choose OS (multi Level, e.g. Windows and then Image e.g. Windows 2025 with SQL 2025)
			3. Instance Type -- Choose Ram and CPU
				t2.nano --> t2 is family and nano is size
				families
					General Purpose - (T, M, A)
					Compute Optimized - (C)
					Memory Optimized - (R, X, U)
					Storage Optimized - (I, D, H)
					Accelerated Computing - (P, G, Inf)
			4. Key Pair
				When we create a Key Pair, 2 keys get created. Private key to be placed on our laptop and public key gets installed on EC2 instance. Dig more as per instructor, private key is sent to the EC2 instance while logging in using ssh. why would we snet private key
				
			5. Network
				Choose Network
				Subnet
				Auto-assign  public IP
				Firewall Security Group (Create rules as to which traffic is allowed and which is bocked). e.g. allow SSH traffic from select list of IPs, allow HTTP/HTTPS from internet (to specific port)
				
				ssh is protocol to connect to linux and mac machine?
				rdp is protocol to connect to windows machine
				http is called to send request on web server (we can allow on specific port)
				
				default ports 
					http 80
					https 443
					ssh 22
					nfs?
					icmp?
					http/https/ssh are tcp
					what are in UDP?
			
			6. Storage
				Either Root Volume or additional EBS Volume
				
			7. Advance Details 
				User data - optional (check rest of the things)
				Run some shell script as soon as instance is created
				eg.
					sudo sudo
					yum update -y (updates all installed packages)
					yum install httpd -y (installs an apapche server)
					service httpd start (starrt web server)
					chkconfig httpd on (check if its on)
					echo "Hello from AWS"> /var/www/html/index.html
					
			chmod 400 key.pem (to lower access on the our key file)
			ssh -i key.pem  ec2-user@publicIP
			
			When the instance gets created, we see public IP and Private IP.
				Public is to be used for internet traffic (hhtp /ssh).
				Private IP is for internal AWS communication). 
				Every AWS resource has a private IP. Public IP is optional (e,g, DB, cache)
				
			Public IP is unique in the world and thats why it is expensive.
			Restarting EC2 instance will get same Public and Private IP
			Stopping and Starting EC2 instance will get new Public IP and same Private IP
			So we need an Elastic Public IP (Static) as it does not change.
			NOTE - We can buy public IPs on internet.
			
			Cost 
				Private IP --  Free
				Public IP -- .005 USD per hour
				
	IAM
		IAM is a service, we can create a resource 
		

15th March -- Anuj -- EC2 Hands-On
	Assignment --  Module 2 - Assignment 1
	Problem Statement:
		You work for XYZ Corporation. Your corporation wants to launch a new
		web-based application using AWS Virtual Machines. Configure the resources
		accordingly for the tasks.
	Tasks To Be Performed:
		1. Create an instance in the US-East-1 (N. Virginia) region with an Ubuntu
		OS and install Nginx for making them web servers.
		2. Change the default website with a page displaying the message: "Hello World"
	
	
		Launch an EC2 Instance
			sudo apt update
			sudo apt upgrade -y
			apt install nginx -y
			cd /var/www/html
			sudo rm index.ngnix-debian.html
			sudo touch index.html
			sudo nano index.html --> type text Control+S --> Control+X
		What is NGNIX -- NGINX ("engine-x") is a high-performance, open-source web server, reverse proxy, load balancer, and HTTP cache.
		It is mainly used for reverse proxy. hoefully we will discuss this in future sessions.
		
		Launch an EC2 Instance with user scripts
		Did not work
		#!/bin/bash
		apt update
		apt upgrade -y
		apt install ngnix -y
		systemctl start nginx
		systemctl enable nginx
		cd /var/www/html
		rm -f index.ngnix-debian.html
		touch index.html
		cat <<EOF> index.html
		<!DOCTYPE html>
		<html>
			<head>
				<title>Hello World</title>
			</head>
			<body>
				<h1>Hello World</h1>
			</body>
		</html>
		EOF
		
		Even this did nt work
		#!/bin/bash
 
		# Update packages
		apt update -y
		 
		# Install nginx
		apt install nginx -y
		 
		# Start and enable nginx
		systemctl start nginx
		systemctl enable nginx
		 
		# Remove default nginx index file
		rm -f /var/www/html/index.nginx-debian.html
		 
		# Create new index.html with Hello World
		cat <<EOF > /var/www/html/index.html
		<!DOCTYPE html>
		<html>
		<head>
		<title>Hello World</title>
		</head>
		<body>
		<h1>Hello World</h1>
		</body>
		</html>
		EOF
		
21st March -- Alia -- EC2 Case Study 
	Assignment --  Module 2 - Case Study - EC2, EBS, EFS
	Problem Statement:
		You work for XYZ Corporation. Your corporation is working on an application and they require secured web servers on Linux to launch the application.
	Tasks To Be Performed:
		1. Create an instance in the US-East-1 (N. Virginia) region with Linux OS and manage the requirement of web servers of your company using AMI.
		2. Replicate the instance in the US-West-2 (Oregon) region.
		3. Build two EBS volumes and attach them to the instance in the US-East-1(N. Virginia) region.
		4. Delete one volume after detaching it and extend the size of the other volume
		5. Take backup of this EBS volume.	
	
	EBS -- Elastic Block Store - is a high-performance, block-level storage service for Amazon EC2, offering persistent data storage that survives instance failure
	
	EBS is only attached to single EC2 instance. Only exception is multi attach EBS. This can also be used for EC2 instances within the same AZ.
	
	1. Create EC2 instance using Amazon Linux
		putty ssh -- ec2-user@ec2-3-95-180-0.compute-1.amazonaws.com using ppk
		sudo yum update
		sudo yum install httpd
		sudo sysctl start httpd
		sudo sysctl enable httpd
		type public IP -- it should be working...
	2. Select Instance --> Actions --> Image and Template --> Create Image. This creates an image that can be used to create EC2 instace in other regions.
		Select Images --> AMI --> Select AMI --> Actions --> Copy --> Copy to Oregon
		Launch a new EC2 Instance using this AMI
		Launch Piblic IP URL and it should work (change from https to http)
	3. Create 2 new EBS volumes in and attach them to NV instance
	4. Detatch 1st volume and detatch and then delete it. Modify the 1st additioanl volume size
	5. Backup -- not completed as theory is not done
	
	Repeat same using nginx
	Launch an EC2 Instance
		sudo apt update
		sudo apt upgrade -y
		sudo apt install nginx -y
		cd /var/www/html
		sudo rm index.ngnix-debian.html
		sudo nano index.html --> type text Control+S --> Control+X
		

22nd March -- Puneet -- Storage
	Types of Storage AWS offers
		Block Storage
		File Storage
		Object Storage
	
	Block Storage
		Data is divided into small chunks and stored in a disk abstract to us. We dont even get to know that data is divided in separate chunks. These are faster, but how?
		Block storage are of two sub types
			Instance Storage
			Elastic Block Storage
			
			Instance Storage are Ephimeral Storage -- Data stored here gets lots when we restart the instance. These are attached to the physical server. When an EC2 instance is created from this Physical server, AWS applies Virtualization and gives us an EC2 instance. I can configure my EC2 to have an instance storage. This is given from the same physical Server, this is fast and better performant. But downside is that it is ephimeral. When we restart the instancem this EC2 instance might come from some other physical server (there are many physical servers in a Data Center). So the date here is not persistent.
			What is a valid use case? It is perfect for caches, buffers, scratch data, and high-performance processing, offering extremely low latency.
			Instance storage is auto created based in instance type, we cannot choose or change size. e.g. c5d.large comes with 100GB instance storage. volume name is ephemeral0.
			
			Elastic Block Storage -- are persistent storage. These are attached over a network. These are not given from same physical server. These are given from an outside storage. This storage is blocked for us, till we delete it. so the data here stays till delete. 
			Even OS is stored here, else when we restart, we wont have any OS.
			Can we attach same EBS to multiple volumes? - only if the EBS Multi-Attach feature is enabled, and specific conditions are met
			
			We can attach more than one volume to an EC2 instance. Each EBS, when attached to an instance, gets shown in as volume in Block Devices.
			*** EBS size can only be increased, it cannot be decreased. Min size is 1 DB and max is 64TB.
			EBS can be created in two volume types -- different types of SSDs and HDDs. 
			
			EBS can be attached to EC2 only if they are on the same AZ.
			
			lsblk -f : this command will list all block drives (drives)			
			Note -- Fresh EBS does not have a file system (it is raw volume). so nothing can be stored here as this volume does not  have any file system . how to create?
			sudo mkfs -t xfs /dev/nvme1n1 (nvme1n1 is the volume name)
			df -h this shows volumes and some info (only the ones which are mounted). This does not show our new EBS (in both cases when raw or even after adding mkfs). So we need to first mount it.
						
			sudo mkdir /data : create a directory on root ebs where we will mount this.

			sudo mount /dev/nvme1n1 /data
			df -h : now this will show info about our new volume.
			
			edit /etc/fstab to add mount information (so that when we restart, we do not loose mountine)
			
			Summary -- additionally attached volumes can only be used after we create filesystem on volume and mount it.
			
			Q - In read world, we may have app deployed to multiple regions (may also be in multi AZ within a region). We will need to attach a persistent storage to EC2 instance across regions? but EBS wont allow that. How would we solve this problem --> EBS is not meant for this. Solution is EFS and S3. We will see that in future sessions.
				
			How to port instance and EBS to another region?
				take backup of the instace and volume and then copy over to another region. We can then use this to recreate an instance in any other region. We will first need to copy the AMI to the region where we want the new instance to be created from the AMI.
				Select Instance --> Actions -->  Image and templates --> Create image
				When we create an image from an insance, root EBS volume is part of the image. Additionally, we can include additional volumes.
				Note -- backup of an EC2 instance is AMI and Backup of volume is snapshot. AMI will show the snapshot for each volume. Snapshots are imcremental. Only keeps change from previous shapshots. When we delete older snapshots, the data is cascaded to the next snapshot in chain. So we can safely delete older snapshots. - https://docs.aws.amazon.com/ebs/latest/userguide/how_snapshots_work.html
				We can also create a snapshot of a storage.
				Amazon EBS snapshots and many Amazon Machine Images (AMIs) are stored in Amazon S3
				We can use AWS backup service to take daily / scheduled backups
				
			How to measure performance of a storage. Useing two metrics
				Throughput -- How much data can go in and out per second (mbps)
				IOPS -- How many operations are possible in per second. Input Output Per Second. 12000 iops means 12000 people/threads can perform operation per second. 
				
				Based on this, we can choose the type of the volume. SSDs are high iops vs HDDs are better at throughput. - https://docs.aws.amazon.com/ebs/latest/userguide/ebs-volume-types.html
				
				SSD types
					General Purpose (99.8% - 99.9% durability)
						GP2 -- 16000 max Iops
						GP3 -- 80000 max IOPS
					Provisioned IOPS SSD VOlumes (High Available)
						io1 -- 99.8% - 99.9% durability -- 64000 iops
						io2 -- 99.999% 256000 iops
				HDDs
					Throughput optimized (st1) (used for big data processing)
						Max IOPS - 500
						Max Throughput -- 500MiB/s
					Cold HDD (sc1) -- used for backups
						Max IOPS - 250
						Max Throughput -- 250MiB/s
						
				We should use SSD for frequent read and writes (but it is expensive)
				Root volumes are always SSD
					
				EBS Volume Multi attach -- same EBS volume can be attahced to multiple EC2 instance. EBS is not made of multi attach / shared storage. We can still do it with limitations. only io1 and io2 EBS volumes can be attached to multiple EC2 instances (within the same AZs only). Additionally the EC2 instances also need to be of Nitro types. etc.
					
	
28th March -- Avni -- EBS Storage Handson
	EBS stores data in fixed size blocks
	
	Question -- If we have 100s of app. We should not have 100s of EC2 instances. rather we should have 100s dockers container deplyed on the E2 instance so that we do not need to duplicate the OS. But with this approach, we will be paying for an EC2 instance even when docker is running at lower capacity? isnt that against the cloud concept? I am sure this is solved but how?
	
	Uses of EBS
		Root Volume is always EBS SSD. OS is stored here. any files created are persisted here, unless we delete the EC2 instance.
		
		Database -- DB requirements is high iops. so MongoDB, etc uses EBS. 
		
		Backup and recovery. Create snapshot (we already discussed, this is incremental and cascaded upon deleting older backups)
		
		Big Data - -as EBS provides scalable storage
		
	Key Characterstics of EBS
		Persistent Storage
		High Availability -- can be replicated within AZ. Note -- not outside
		Scalable -- size can be increased. Also we can attach more than one EBS to out EC2 instance. 
		Snapshots and Backups
		High Performance
		AZ Specific.
		Multiple types offered
			SSD -- optimized for transactional workloads involving frequent read/write operations with small I/O size. High Performancy and low latency
				General Purpose
					gp2 -- (1 GiB - 16 TiB) (16,000 IOPS) (250 MiB/s)
					gp3 -- (1 GiB - 64 TiB) (80,000 IOPS) (2000 MiB/s)
				Provisioned IOPS
					io1 -- (4 GiB - 16 TiB) (64,000 IOPS) (1,000 MiB/s)
					io2 -- (4 GiB - 64 TiB) (256,000 IOPS) (4,000 MiB/s)
					
			HDD -- optimized for large streaming workloads where the dominant performance attribute is throughput
				Throughput Optimized
					st1 -- (125 GiB - 16 TiB) (250 IOPS)
				Cold Storage
					sc1 -- (125 GiB - 16 TiB) (500 IOPS)
					
	Problem Statement: 
		You work for XYZ Corporation. Your corporation wants to launch a new web-based application using AWS Virtual Machines. Configure the resources accordingly with appropriate storage for the tasks. 
		
		Tasks To Be Performed: 
		1. Launch a Linux EC2 instance. 
		2. Create an EBS volume with 20 GB of storage and attach it to the created EC2 instance. 
		3. Resize the attached volume and make sure it reflects in the connected instance
		
		sudo apt update
		sudo apt upgrade -y
		sudo apt install nginx -y
		lsblk -f
		sudo mkfs -t xfs /dev/nvme1n1
		sudo mkdir /data
		sudo mount /dev/nvme1n1 /data
		sudo blkid /dev/nvme1n1
		sudo cp /etc/fstab /etc/fstab.orig
		sudo nano /etc/fstab
			Stuck here as the fstab has LABEL instead of UUID
		 Add --> UUID=191b4ff1-c37d-444a-a52e-0a2a24d646b2 /data xfs defaults,nofail 0 2 or LABEL=DataVol    /mnt/data      ext4   defaults,nofail 0       2
		
			LABEL=cloudimg-rootfs   /        ext4   discard,commit=30,errors=remount-ro     0 1
			LABEL=BOOT      /boot   ext4    defaults        0 2
			LABEL=UEFI      /data       xfs    umask=0077      0 1

29th March -- Puneet -- EFS -- Elastic File Storage.
	EBS cannot be used across AZs and also can be used only withing 1 instance (exceptions apply). EFS can be used for cases where we want to use it across regions, multi instances. 
	
	EBS - we pay for to storage by size of the Volume. (if Vol is of 8 GB but we store 1 GB, we still pay for 8GB). EFS is just file store, we pay by the size of files. Can scale up or down.
	
	Usecase -- Shared file storage to be used by multiple compute instances.	
	
	When we create EFS, we choose following	
		Network -- VPC where we want to use the EFS
		Regional or AZ 
		Auto backup (Amazon BackUp Service is used internally to create backups)
		Lifecycle Management. Files that are used frequently are made available easily (related to Storage Class)			
		Storage Class
			Standard -- default
			Transition into into infrequent access
			Transition into Arhchive.
		
		Encryption (used KMS - Key Management Services)
		
		Performance
			Enhanced
				Elastic (AWS recommended). Throughput changes with current volume of data being accessed
				Provisioned (fixed throughput)
			Bursting
				throughput changes with size of the data stored
		Mount Target
			Endpoint in every AZ (one per AZ)
				
			Lets say we have 3 AZs in our region. e.g. ap-south (1a, 1b, 1c)
			If we want to use our EFS from instances across all AZs. We will first need to create a network that spans across all AZs within the region. And then we need to have end points (Mount Target) in each AZ (exactly 1). Then we can use this enpoint, to point to our EC2 instances in all AZs. Note the mount targets (end points also get assigned an IP from within the VPC). Event Mount point will also have a Security Group.
			Note -- to mount the EFS, we need to create a directory in our EC2 and then use mount command to mount. This command goes to Mount point but it will block traffic from EFS to EC2 if its security group is not allows to and from traggic.
			
		File System Policy
			Prevent Annonymous access
			Enforce Readonly
			Prevent root access, etc
		
		Create EC2
			Check Volumes
				df -h (obviously does not show EFS)
			Install EFS Client (needed in each EC2 where EFS is to be used) or NFS Client. EFS is auto managed (auto scales, etc).
				sudo yum install -y amazon-efs-utils
			Create Directory
				sudo mkdir /dir1
			Mount (not yet.. if we do not, we will get timeout coz Security Group will not allow)
				sudo mount -t efs -o tls *** (get this from console)
			Create a new Rule in SG to allow traffic
				Allow NFS from Security group of the EC2
			Now run mount command
			run df -h (we can see now)
			cd /dir1/
			sudo nano 1.txt (this file can be seen from another EC2)
			now update fstab to persist the mounting (to be used afer restart)
			
		NOTE -- EFS CANNOT be mounted on any Windows OS Instance. So what do we do to use a file sytem from a Windows EC2? Use FSX. It can be used from both linux and Windows
		
	FSX -- is not given in free tier. It is expensive, very high performant. Very High IOPS and throughput. We can also use FSX in Linux (when high performance is needed). ML, etc.
	FXS Luster is only for Linux (even more performant, millions of iops)
	
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
		
	
4th March -- TA Avni -- EFS Handson -- Module 2 Assignment 3
	recap of pervious session
	NFS --> 
		Amazon Linux / Redhat uses nfs.unitls
		Ubuntu NFs -common
		
	Tasks To Be Performed: 
		1. Create an EFS and connect it to 3 different EC2 instances. Make sure that all instances have different operating systems. For instance, Ubuntu, Red Hat Linux and Amazon Linux 2.
	
	Note to self 
		-- test it out with  the EFS mount helper instead of NFS (See the EFS --> Attach screen)
		-- Also test by ot using default SG
		-- EBS mounting was not working, test that out
	Ubuntu uses apt as package manager
		sudo apt update
		sudp apt upgrade -y
		sudo apt install nfs-common
		mkdir efs
		copy command from EFS --> Attach UI
		cd efs
		touch fileFromEC2.txt
	Amazon Linus uses yum as package manager
		sudo yum update
		sudo yum install nfs-utils -y
		sudo yum upgrade -y
		mkdir efs
		copy command from EFS --> Attach UI
		cd efs
		we should see fileFromEC2.txt here 
	RedHat -- Use putty	
		sudo yum update
		sudo yum install nfs-utils -y
		sudo yum upgrade -y
		mkdir efs
		copy command from EFS --> Attach UI
		cd efs
		we should see fileFromEC2.txt here
		
5th April 2025 -- IAM
	Authentication
	Authorization
	
	User, Groups, Policy
	
	AWS User
		Root
		IAM
			Limitted acces (as assigned by Root). 
			How to create?
				IAM --> Users --> Create User and provide following
					User Name
					Access to Management Console (if not given, user is forced to use CLI or programatically)
					Password  (Autogenerated or Custom)
					Groups, policy (etc, to be looked at later)
			What do we get?
				Console URL,  UserName and Password, 12 digit AccountId
			Note -- This is the same AWS account as root user but its just another user. Billing is on the same AWS account.
			
	Policy -- is a bundle of permissions
		Two Types -- AWS Managed Policy and Customer Managed Policy
			AWS Managed Policies -- Grant read access to ECE, Grant full Access to EC2. What if we want something more specific that AWS standard policy does not offer? e.g. Full EC2 access except some critical EC2 instances. We create Custom Policy
		How to give Permissions to User? Three ways
			Create a Group and assign permissions to that group and andd User to Group. This is reusable
			Copy Permission from some other User. Resuable but restricted. If new permission is given to the original user, that wont be granted to other users
			Attach Policies Directly. Maintain permissions individually for each user (difficult to maintain)
	
	When we create IAM user, we get a userName and Password, where do we store this? So this is an overhead, specially, if we have thousands of Users
	
	ARN -- ARN is Amazon Resource Name. Every Resource has a Name. 
	
	Service Vs Resource -- We use EC2 Service to create an EC2 Resource. Every EC2 resource (instance will have a unique ARN). Note every Resource has an ARN. E.g. EC2 instance, EBS storage, EFS Strorage, UserName, Policy, Security Group, etc, etc (every resource will have and ARN).
		ARN Naming format -- arn:aws:Service:Region:AWSAccount: (come back)
							 arn:aws:EC2:
							 arn:aws:IAM:: (this is global to region is missing)
	How to create a Policy
	IAM --> Policies --> Create Policy
		Effect (Allow / Deny)
		Manual Action (Choose Service e.f. All EC2, All EBs, etc)
		List
			Permissions (Describe Instances, etc)
		Read
			Permissions ()
		Write
			Permissions (Start Instance, Stop Instance, Terminate Instances)
		Resources
			All / Specific ARNs
	NOTE -- If we give contradiction permissions in policy. e.g. Allow full access to all EC2 and then later Deny access to 2 specific Instances, DENY will get the preference. So basically allow all except two.
	
	All Policies are written in JSON. We can create via the UI which is easier but we can also do this programatically using AWS services to apply updated JSON.
	
	Policy Editor, we can also directly update policy json via UI
	Policy JSON	
		Version
		List of Statements
			Statement1
				Sid - unique statementID
				Effect -- allow / Deny
				Action -- List of permissions e.g. 
					ec2:DescribeInstance
					ec2:TerminateInstance
				Resources -- * for all or ARNs
			Statement2
			
	Similarly, we can create a group and assign users to group.
	
	Create MFA for new IAM user.
	
11th APril 2026 -- IAM Continuation

Revision
	User Types
		Root (Admin)
		IAM (created by Root or other IAM if IAM has permission to create User)
	Policy Types
		AWS Manages Policy (Fixed)
		Customer Managed Policies (Custom)
		
Todays Topics
	Role
	AWS CLI
	
	Role
		Trust Policy -- Who can take this Role?
		Permission Policy -- What permissions will be granted to the people belonging to this Role.
	
	Q1. How to grant access to other AWS account holders to manage resources on our AWS account? As per current knowledge, create an IAM user for account holder.
	
	Q2. Lets say we have one AWS account in ur ORG and we want 100 Users to have access to it. One way is to create IAM for all users. But this comes with overhead to manage and ship credentials. Also to delete access when user leaves org. How to solve this?
		
	Lets solve Q1 and Q2
	Create a new Role and define
		Trust Policy -- Other AWS account holder's Id will be added in Trust Policy.
		Permission Policy -- What this Role can do, Start-Stop Ec2
		Validity (12 minutes to 12 hours)
		Note -- Roles are temporary. Internally Security Token Service is used. Once the Role is created, other AWS account holder will have to send request to assume this role which goes to STS to access that role, and STS grants temporary token (it checks trust policy defined for the role).
		Once granted, user can access / assume the role.
	
	Trust Policy Options
		AWS Service
			Create policy for EC2 service
		AWS AccountId
		Web Identity
			Login via FB/Google, etc
		SAML 2.0 Federation
		Custom Trust Policy
		
	Note -- When a User is granted a Role does not mean the User gets those permissions by default. He will have to switch the Role by supplying the Account ID and Role Name and ask STS to grant ticket and then user can access till the time his ticket is valid. And then once tasks are performed, User can switch back to original user. So this is not like a traditional role given to the user. This is like User assuming a Role temporarily and then switching back to its original Role / access
		
		
	Install AWS CLI on personal PC
	Commands - https://docs.aws.amazon.com/cli/latest/
		aws login
		
	EC2 Instance --> Actions --> Security --> Modify IAM Role
		We can create a Role for our EC2 and run app under that role (STS ticket to get renewd upon expiry). All access needed by the app must be managed under that role.
		
	Question
	Lets say we have an EC2 instance running multiple Containers (app component1, app component2, etc).
	Each component may need diff set of accesses and lets say we have created multiple roles.
	How would we assume roles in individual containers?
	
	IAM Done
	
CloudWatch
	Monitoring and Observability
		e.g. Monitoring EC2 instance (CPU, RAM, IO, etc)
CloudTrail
	maintains audit of anything that happens to our resources