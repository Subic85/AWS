AWS

7th March 2026

AWS Account Creation and Intro

https://docs.aws.amazon.com/

https://docs.aws.amazon.com/accounts/latest/reference/manage-acct-creating.html

Geographic regions Vs Availability zones 
	Availability zones = Data Center 
	Every region has atlease 3 availability zones
	One country may have more than one region, similarly, multi countries can have a shared region
	
Cloud Computing
	On Demand IT resources
	pay-as-you-go pricing model
	basically renting as against buying.

Biggest AWS Customers
	3M, AirBnb, Netflix, Coca-Cola, Formula1, etc
	
Biggest AWS Customers by revenue
	Sony (11M$/month), Adobe(7.5M$/month), Facebook, Johnson & Johnson, 3M

https://miro.com/app/board/uXjVGIZb0og=/?share_link_id=354028704040

Cloud Providers
	AWS
	GCP
	Azure
	Oracle
	IMB
	Alibaba
	OpenShift

Types of Cloud
	Public 
		Cloud resources
	Private
	Hybrid

Service Models
	IaaS		
	PaaS		
	SaaS

Benefits
	Pay-as-you-go
	Scalability
	High Availability
	Global Access
	
8th March 2026 AWS Intro
	Intro (already known)
	Create an EC2 (Elastic Compute)
	Create S3 (Simple Storage Service)
	
	AWS was first created for Amazon's self use. Later they realized potential of allowing others to leverage it so they release AWS to public.
	
	Regions and Availability Zones
	
	Region is a an AWS Geo area (logical not physical)
	Availability Zone (AV) is logical separation within a region. Each Region will have atleast 3 AVs
	Data Center is a physical building where machines reside. Each AZ, will have atleast 1 Data Center
	Edge Location is used for faster CDN (Each Data Center has one or more Edge Locations)
	Every Data Center is isolated, so by default Activity Zones and Regions are also isolated
	We may have more than 1 data center located at same geography 
	Each AV acts as an independent isolated zone. Any calamity in one zone should ideally not affect another zone.
	
	
	Region is a Geo area when AWS has multiple data centers. Each region is completely independent and isolated from other regions.
		
	Region (Spread across the world)
		Availability Zones (min 3 in reach region, logical separation within a region)
			Data Center 1 (building 1) (minimum 1 Data Center in each AZ)
				Edge Location 1 (Used for CDN)
				Edge Location 2
				Edge Location n
			Data Center 2 (building 2)
				Edge Location 1
				Edge Location 2
				Edge Location n
		Availability Zones
			Data Center 1  (building 1)
				Edge Location 1
				Edge Location 2
				Edge Location n
		Availability Zones
			Data Center 1  (building 1)
				Edge Location 1
				Edge Location 2
				Edge Location n

	Edge Location helps with CDN. Lets say content is in US and people start watching in Mumbai, so AWS will keep a cached copy in Mumbai edge location so that latency can be reduced.












