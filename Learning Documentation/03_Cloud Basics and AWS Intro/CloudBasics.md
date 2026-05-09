# Cloud Basics and AWS Intro
###### 7<sup>th</sup> and 8<sup>th</sup> March 2026 - TA Anuj and TA Alia

* [Before Cloud](#before-cloud)
    * [Problems of Owning and Managing Data Centers and Servers](#problems-of-owning-and-managing-data-centers-and-servers)
	    * [Capital Expenditure](#capital-expenditure-capex)
	    * [Resiliency Challenges](#resiliency-challenges)
		* [Plan for Maximum Capacity](#plan-for-maximum-capacity)
		* [Platform Dependency](#platform-dependency)
* [Cloud Computing](#cloud-computing)
    * [Benefits of Cloud Computing](#benefits-of-cloud-computing)
	* [Major Cloud Providers](#major-cloud-providers)
	* [Cloud Deployment Models](#cloud-deployment-models)
	* [Cloud Service Models](#cloud-service-models)
* [AWS Intro](#aws-intro)
    * [Top Global Applications on AWS](#top-global-applications-on-aws)
	* [AWS Account Creation](#aws-account-creation)
	* [AWS Official Documentation](#aws-official-documentation)
	* [AWS Global Infrastructure](#aws-global-infrastructure)
	* [AWS Services Vs Resources](#aws-services-vs-resources)
	* [Which AWS Region to Choose](#which-aws-region-to-choose)


## Before Cloud
Before Cloud, in order to host an application, an organization had manage following aspects
1. Purchase physical hardware (Servers, Memory, Storage, etc)
2. Purchase Operating System and other Softwares (as needed)
3. Purchase Routers, Switches and other networking equipment.
4. Purchase or rent space for the hardware
5. Purchase cooling equipments and power backup equipments
6. Hire (full time or on-demand personnel to manage the hardware and network)
7. Ensure physical safety of the hardware (security guard, camera, alarm system, etc)
8. Deploy and maintain application code. 
9. Pay Utilities for power and regular maintenance. 

### Problems of Owning and Managing Data Centers and Servers

#### Capital Expenditure (Capex)
This expenditure before we can even host our wep application is called Capital Expenditure. This is a huge problem due to following aspects
1. We need to spend a huge amount of money upfront
2. Risk of loss of this Capex if the business does not do well and we want to opt out. All this Hardware needs to be sold at a huge loss.  

#### Resiliency Challenges
Resiliency was a big challenge, specially for small organizations who could manage the Hardware in only one geography, app may go down, when that geography is hit by any calamity like
1. Power Outage
2. Floods
3. Fire,
4. War, etc

### Plan for Maximum Capacity
We always need to pan for peak usage and entire infrastructure is build for max capacity. This means, we waste additional resources during off-peak hours.

### Platform Dependency
If we have hardware and OS that supports a particular platform such as windows, all our apps should be written in a framework that supports the platform, this adds platform dependency.  
Technically, this can be solved by adding HyperV and then spinning up Virtual Machines with any desired OS but they have overheads to manage.  
**Note** - Some HyperV can work directly over bare-metal and do not need any base OS.

## Cloud Computing
Cloud computing is the on-demand delivery of IT resources over the Internet with pay-as-you-go pricing. Instead of buying, owning and maintaining physical data centers and servers, you can access technology services, such as computing power, storage and databases, on an as-needed basis from a cloud provider like AWS, Azure, GcP, etc.

### Benefits of Cloud Computing
Cloud computing has several benefits to end user, such as
1. **Cost Efficiency** - Cloud is Pay-as-you-go model so we only pay for resources we use (by minutes). If we use three servers during day time and only one at night time, we only pay for the usage.
2. **Global Reach** - We can choose where to run our code, we can be closer to the user base to minimize latency
3. **High Availability** - We can run our apps and services in multiple locations so that if one goes down (do to any reason), the app and service can be served from the other location.
4. **Scalable** - We can scale-in and scale-out based on the usage at run time.
5. **Enhanced security** - comes out of the box
6. Many other out of the box features such as regular backups, alerts (if something goes down or up)
7. **On-Demand Availability** - We no longer need to wait weeks to procure new hardware.

### Major Cloud Providers
1. AWS  Amazon Web Service
2. Azure - Microsoft 
3. GCP - Google Cloud Platform
4. Alibaba - Dominant in Asia
5. Oracle Cloud
6. IBM Cloud

### Cloud Deployment Models
1. **Public** - In this deployment model, all resources and services are used from public cloud. This is a multi tenant model where applications from multiple tenants resides in same data center, however each tenant is hosted in in its dedicated network, so its isolated for safety
2. **Private** - In this deployment model, all resources and services used are from an on-premise private cloud that is hosted for a single tenant / organization. Example, NASA may want to host all its applications in an on-premise private cloud.  
**How is this different that hosting in its own on-premise data center?**  
Main difference is having a means to provide pay-as-you-go model. Each app does not need to plan for max capacity, we can rent additional resources as needed and release them when not needed. This saves over 40% of the cost.
3. **Hybrid** - In this model we use best of both worlds. We may have compliance to keep certain data on-premise or we may have some legacy application that are not suited for public cloud, they can can remain on-premise and rest of the apps and services can remain in public cloud.

### Cloud Service Models
1. **IaaS - Infrastructure as a Service**  
Offers fundamental computing resources such as Servers, Storage, Networking, etc over the internet. User manages, application, Data, Operating System while the cloud provider manages physical infrastructure.  		
2. **PaaS	- Platform as a Service**  
Provides a cloud-based environment for developing, testing, and deploying applications, enabling faster development cycles without managing underlying infrastructure (e.g., Google App Engine, Salesforce Lightning)
3. **SaaS - Software as a Service**  
Delivers fully functional software applications over the internet, managed entirely by the provider. Examples include Google Workspace, Microsoft 365, and Salesforce
4. **Faas - Function as a Service**  
Breaks applications into smaller components that only run when needed, allowing developers to pay only for the exact execution time, further reducing idle costs
	

## AWS Intro
AWS is Amazon's cloud infrastructure that provides users with over 200 Services and features over public cloud which can be used to host small, medium and large scale application across the globe. It provides various services such as
1. Compute Power like Virtual Machines
2. Storage
3. Databases
4. Networking components 
5. Domain Name Resolution and Registrar
6. Load Balancing 
7. Auto Scaling 
8. Monitoring and Alerts and many more.

#### Note
* AWS was first created for Amazon's self use. 
* Later they realized potential of allowing others to leverage, so they released AWS to public.

### Top Global Applications on AWS
1. Netflix - Has over 100,000 servers in AWS with annual spend of over a Billion Dollars. 
2. Twitch 
3. LinkedIn
4. Facebook
5. Amazon Prime Video
4. eBay
5. McDonalds
6. Capital One
7. NASDAQ
8. Airbnb


### AWS Account Creation
To create an AWS account, go to below links and follow instruction.  
[AWS Account Creation official documentation](https://docs.aws.amazon.com/accounts/latest/reference/manage-acct-creating.html)

### [AWS Official Documentation](https://docs.aws.amazon.com)

### AWS Global Infrastructure
AWS infrastructure is divided into multiple **Regions**. Each region is further divided into multiple **Availability Zones (AZ)**. This Availability Zone is a physical Data Center is an isolated unit with following properties
1. Has its own **generator and cooling** equipments
2. **Isolated Power** supplied by different power sub stations
3. **Dedicated Networking** - Dedicated metro fiber designed to prevent network isolation failures.
4. **Physical Separation** - AZs are positioned apart (several Kilometers) to avoid shared failure risks but close enough to support synchronous replication.

AWS has 39 Geographic regions and 123 Availability Zones
https://aws.amazon.com/about-aws/global-infrastructure/regions_az/

![AWS Regions and Availability Zones](images/AWSRegionsAndAZs.svg)

#### Edge Location
**Edge locations** are separate, smaller endpoints used for CloudFront content delivery (**CDN**), distinct from the core data centers in an AZ. Edge locations do not reside inside AWS Availability Zones (AZs). There are over 750+ Edge Locations globally

#### Note
* Every Region has a minimum of 3 Availability Zone. 
* One country may have more than one region, similarly, multi countries can have a shared region
* North Virginia is the most popular Region, most services and features are first rolled out here.

### AWS Services Vs Resources 
AWS Services can be used to create an AWS Resource. E.g. we can use EC2 service to create many EC2 virtual machines / servers. Each EC2 VM is a resource which is created using the EC2 service.  
1. **Global Service** - These services can be used at global level. e.g. **IAM** (Identity and Access Management), **Route 53** (DNS )
2. **Regional Service** - These can be used at regional level e.g. **ASG** (Auto Scaling Group), **ALB** (Application Load Balancer)
3. **Zonal Service** - These can be used at AZ level. e.g. **EC2** (Elastic Compute Cloud), **EBS**(Elastic block Storage)

#### Which AWS Region to Choose
Some considerations while Choosing an AWS region
1. Closer to majority of the user base
2. Business Compliance (bank may want to keep all data in host country)
3. Governing law (country specific law)

#### Notes from Trainer
https://miro.com/app/board/uXjVGIZb0og=/?share_link_id=354028704040