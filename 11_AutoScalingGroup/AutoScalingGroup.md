# Auto Scaling Group
###### 18<sup>th</sup> April 2026 Puneet Gavri (Post Break)
ASG automatically adjusts the number of EC2 instances in a group to meet demand, enhancing availability and lowering costs. It keeps application performance stable by adding instances during traffic spikes and removing them when demand drops, ensuring high availability through automatic health checks and replacement. 

##### Note(s)
- This is only application for EC2 instances.
- So this is part of the EC2 services

## Vertical Scaling 
Vertical scaling is upgrading single EC2 instance's capacity by increasing / decreasing its resources such as CPU, RAM, Storage, etc.
##### Note(s)
- AWS does not give you out of the box option for Auto Vertical Scaling. 

## Horizontal Scaling
Horizontal scaling is adding / removing EC2 to the existing fleet of EC2 instances.
##### Notes(s)
1. Size of all instances is the same 
2. These EC2 instances must be under a Load Balancer. 
3. Health check needs to be configured so that request is not sent to unhealthy instances. 

## Scaling Out Vs Scaling In
Scaling-Out is when we are adding more instances to the fleet, and Scaling in is when we are removing instances from the fleet.  
Scaling out  <--->  
Scaling In   --><--

## Launch Template 
This is the template that is used by the ASG to create new Instances. This defines how our new EC2 instance is to be configured. e.g.   
1. AMI,
2. Size, 
3. User Data
4. Network and Security Group
5. Storage
6. KeyValue Pair

## Min Vs Max Vs Desired
We need to define the Minimum and Maximum number of Instances that ASG should maintain. Along with that, we provide a desired number of instances. Note this number keeps changing at run time but it is always between Min and Max. Lets say Min = 1, Max = 4 and Desired = 2. We start our app and we have two instances running. Now, if more load comes in, Desired changes to 3, one EC2 instance is added to the fleet by ASG. Now, if for some reason, one EC2 instance dies, ASG will launch a new instance as Desired is 3 but we have only 2 instances running.

## ASG Creation
EC2 --> Auto Scaling Group
1. Choose Launch Template
    1. ASG Name
    2. Launch Template (Choose or Create)
        1. Similar Configuration to EC2 Launch. 
        2. Additionally, we can define Version Number, this maintains History (or Multiple Versions), allowing us to go back to previous version, if needed.
    3. Version
2.  Network
    1. Availability Zone
3. Integrate with Other Service
    1. Load Balancing 
        1. No LB
        2. Attach an Existing LB
        3. Attach to a new LB

## Demo


19th April
Scaling Policies
1. Dynamic -- Based on Metrics, CPU Utilization, etc. Three types
    1. Target - works around achieving a target value of our metric. 
    2. Simple Scaling  
        Metric breached, action triggers, e.g.  
        * CPU Util > 80, add 2 instances  
        * CPU Util < 40, remove 2 instances
    3. Step Scaling  
        Goes step wise, e.g.  
        * CPU Util > 70, add 1 instance
        * CPU Util > 80, add 2 instance
        * CPU Util > 90, add 5 instance
2. Predictive
    1. AWS records past behavior and scales bases on that. We can choose how far back of data to use for prediction to use.
3. Scheduled
    1. Hot days Vs Cold days

## Auto Scaling Life-Cycle  
https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-lifecycle.html  

LifeCycle states of EC2 instances that are added or removed as part of ASG is mentioned below. We can also listen into some events called LifeCycle Hooks during Auto Scaling and do something programmatically 
- Pending - Before the Instance is being brought up
LifeCycle Hooks on Pending 
    - Pending Wait
    - Pending Proceed
- InService State - Traffic is not sent till the Service reaches in Service State.
- Entering Standby - Pre Step for Standby 
- Standby State - We can manually move an instance to Standby for investigation. During this time, traffic is not sent here. Once analysis is complete, we can put it back to InService. It will go to Pending and then Initial Launch. Instance still remains in the ASG
- Detaching - Pre Step for Detach
- Detached - Instance keeps running but it is not part of ASG so it wont get any traffic. This is not like terminating it. It remains active so that we can perform some operations later (like backup, etc)
- Terminating - Pre Step for Terminate
LifeCycle Hooks on Terminating 
    - Terminating Wait
    - Terminating Proceed
- Terminated