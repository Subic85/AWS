# Load Balancer 
###### 12<sup>th</sup> April 2026 Puneet Gavri

A load balancer acts as a **traffic cop** sitting in front of servers, efficiently distributing incoming network traffic across multiple backend servers to ensure no single server becomes overwhelmed.  
It also improves System Availability by avoiding Single point of Failure

![Load Balancer](images/LoadBalancer.svg)

## Benefits of a Load Balancer
1. **High Availability & Reliability**  
If a particular Server / Node goes down, requests will stop going to the unhealthy node, making the System highly available and reliable. 
2. **Enhanced Performance & Low Latency**  
Request is routed to healthy nodes thereby reducing bottle-neck on a particular node
3. **Seamless Scalability**  
When user load increases, its easer to add more servers behind load balancer, thereby making the System more scalable.
4. **Application Security**  
This becomes the entry point, so when Security Rules are correctly configured, it will terminate unwarranted requests at source and these requests wont reach the Application Code.
5. **Reduced Downtime & Maintenance**  
They enable taking individual Nodes offline for Maintenance or Upgrades, while the other Nodes serve live traffic. This drastically reduces Downtime during maintenance window.
6. **Efficient Resource Utilization**  
When Routing rules are configured correctly, load is evenly distributed on all Nodes. 

# AWS ELB - Elastic Load Balancer
AWS Elastic Load Balancing (ELB) automatically distributes incoming application traffic across multiple targets, such as EC2 instances, containers, and IP addresses, across multiple Availability Zones.  
AWS ELB Service is part of EC2 Service. **This is a Regional Service so it can only be be used within a Region**

## Types of Elastic Load Balancers in AWS
1. **Application Load Balancers**
2. **Network Load Balancer**
2. **Network Load Balancer**

Before we look at these types of Load Balancers, we need to first understand the [OSI model and its Seven-Layer Framework](#osi-model---open-stystem-interconnection).

1. **Application Load Balancer**  
An Application Load Balancer (ALB) operates at Layer 7 of the OSI model. It has capability to intelligently route incoming HTTP/HTTPS traffic to various targets like
    1. EC2 instances
    2. Containers
    3. IP addresses

    Routing rules can be based on  
    1. Content
    2. Path
    3. Host IP
    4. Http Method (Get / Post)
    5. Protocol (HTTP Vs HTTPs)
    6. Port Number.
    7. Query String

    It is ideal for modern, containerized applications and microservices, supporting SSL termination and high availability across multiple availability zones.  

    ![Application Load balancer](images/ApplicationLoadBalancer.drawio.svg)

2. **Network Load Balancer**  
A Network Load Balancer (NLB) operates at the OSI Layer 4 of the OSI model. It has capability to efficiently route high-volume TCP/UDP traffic across various targets like
    1. EC2 Servers
    2. Containers
    3. Virtual machines  
    
    It is designed for extreme performance, managing millions of requests per second with ultra-low latency for use cases like - Gaming or Streaming ap, where performance need is quite high.

    ![Network Load Balancer](images/NetworkLoadBalancer.drawio.svg)

3. **Gateway Load Balancer**  
The AWS Gateway Load Balancer (GWLB) is a managed service designed to deploy, scale, and manage third-party virtual appliances such as firewalls, intrusion detection systems (IDS), and deep packet inspection (DPI) systems. Unlike other load balancers, it operates at Layer 3 (Network Layer) of the OSI model, making it a transparent "bump-in-the-wire" that sits in your network path without altering the traffic source or destination. 

## Demo

Do the following 
1. Create 4 EC2 Instance and start app server like nginx or httpd. Add Login and Payment page respectively. 
2. Make sure we are able to connect them from outside word using public IP.
3. Optional -- we can delete the Public IPs as we will be placing these EC2 instances behind a Load Balancer from within the Region. This Load Balancer will have a  Public IP.
4. Create an Application Load Balancer and do the following 
    1. Choose scheme as Internet Facing (thereby allowing all internet traffic on http port 80)
    2. Choose Network Mapping. Here, choose the same VPC, where our EC2 instances are created)
    3. Choose all Availability Zones where our EC2 instance are created. Note AWS Internal Load balancer Node is created only on these AZs.
    4. Choose a Security Group
    5. Add Listeners -- Define two separate Listeners, one for all /login and other one for all /pay path on http 80
    6. Add Default Action for Each Listener  
        1. Create new Target Groups, one for all Login EC2 and another one for all Payment Ec2 instances
        2. Map EC2 instances to the Target Groups correctly.
    7. Setup Health Checks 
        1. Healthy Threshold
        2. UnHealthy Threshold
        3. Timeout 
        4. Interval
        5. Success Code (HTTPResponse Code)
5. Now that the ALB is setup, update the EC2 instance's Security group to allow http access from ALB's Security Group. 
6. Checkout the Target Group Attributes like Drain, LB Algo, Stickiness,  etc) 

Once this is done, we get a DNS URL on the ALB and we can use this on browser and it will load balance. Test it out 

Similarly, do the Setup for NLB, We will have to create a Target Group

Cross-zone LB Setup
- when off - Requests will be evenly distributed to each AZ (which might be a problem if we have less instances in 1 AZ (taking more load) and more in the other)
- when on -- requests will be equally distributed correctly by EC2 instances (irrespective to the number of instances in each AZ)
- default is ON.

NLB does not follow Round-Robin algo. It uses Flow-Hash algorithm  
Note -- We can add multiple target groups, each having weight from 0 to 99. Requests will be routed to TG based on the weight.

## Questions   
1. ELB Service is Region specific. How to Load Balance global apps then? Use DNS like Route53
2. ALB listens to https, 443, then on within the VPC, is it safe to use http communication? Yes

## Extras  

## OSI Model - Open Stystem Interconnection
OSI model is a conceptual seven-layer framework created by ISO that standardizes netwroking functions to enable diverse systems to communicate. Data Communication is deveided into seven layers from Physical (Layer 1) to User Application (Layer 7).

### The Seven Layers of the OSI Model

<ol reversed>
  <li>Layer 7 - Application: Interfaces directly with user applications (e.g., HTTP, FTP, SMTP).</li>
  <li>Layer 6 - Presentation: Formats, encrypts, and compresses data for the application layer.</li>
  <li>Layer 5 - Session: Manages sessions (connections) between computers.</li>
  <li>Layer 4 - Transport: Handles end-to-end communication, flow control, and error correction (e.g., TCP, UDP)</li>
  <li>Layer 3 - Network: Manages logical addressing and routing packets across networks (e.g., IP).</li>
  <li>Layer 2 - Data Link: Provides node-to-node data transfer and handles physical addressing (MAC addresses).</li>
  <li>Layer 1 - Physical: Transmits raw bitstreams over physical cables or wireless mediums. </li>
</ol>


## Protocols

## SSL Termination



https://github.com/puneetgavri/aws-world