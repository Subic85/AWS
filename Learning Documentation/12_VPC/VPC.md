# VPC - Virtual Private Cloud
###### 25<sup>th</sup> April 2026 Puneet Gavri

AWS VPC is a foundational AWS service that allows us to create an isolated Network where we can create our resources like EC2 instances, RDS databases, etc. It provides full control over following networking assets to customize network configuration, similar to traditional Data Center.
1. IP Addresses
2. Subnets
3. Routes Tables
4. Internet Gateway
5. NAT Gateway
6. Transit Gateway and many more.

This is a regional Service.  
Lets look at some Networking concepts before we start with VPC 

## IP Address
Before we look at IP Address, lets look at what is addressing in general terms. 
### Addressing  
Addressing helps us define unique address to each device so that they can talk to each other. We have two types of Addresses. 
1. Physical Address - This is assigned to the device and does not change. ***e.g. Mac Address***
2. Logical Address - This is a logical address that gets assigned to the device which can change. ***e.g. IP Address***
    * Our device connected to Home Wifi gets some IP
    * Same device connected to Office Wifi gets some other IP. In both cases, the ***MAC address*** remains the same.

### IP Address Types
 We have two type of IP Address. 
1. IPv4
    1. This is 32 bit IP Address which has four octets (sections) each representing 8 bits.  
    2. 8 bits can contain max 255 (converted to decimal). So it can range from 0.0.0.0 to 255.255.255.255.  
    3. Max combination leads us to 4 billion IP address 256 * 256 * 256 * 256
    4. This 32 bits IP Address is divided into two sections
        1. Network bits - Helps us identify specific Network
        2. Host bits - Helps us identify specific devices on the network.
2. IPv6
    1. This is 128 bits IP Address
    2. Future safe
    3. Most common use-case is for IoT - Internet of things (Smart devices)


### CIDR - Classless Inter Domain Routing  
CIDR is a method of allocating an IP address range to a networking asset like a VPC, Subnet, etc.  

#### Notation - 192.168.0.0/16. 
Here 192.168.0.0 is the network address (***note its Network address not IP address***). And the number after the slash, 16 is called masking.  
#### Masking digit
Masking digit indicates number of bits reserved for Network and the rest (32 -16) are reserved for host bits.  
Lets look at this with example  
**192.168.0.0/16 = 11000000.10101000.00000000.00000000/16*** 
So first 16 bits are reserved for the network. i.e. **192.168** (11000000.10101000) are reserved for network, which means this network has IP range from 192.168.0.0 to 192.168.0255.255  

#### Size Calculation 
So in this example we will have 256 * 256 combinations i.e. 65536 combination.  
Formula to calculate number of available addresses = 2 <sup>(32-Masking Digits)</sup> - 5 (i.e 2 <sup>16</sup> - 5 = 65536 - 5 = 65531). Why minus 5? because 5 IPP addresses are reserved in each CIDR
| Which IP | Reserved in in all Networks or only AWS? | Purpose |
| --- | --- | --- |
| First IP | Every Network | Network Identification |
| Second IP | AWS | Local Router |
| Third IP | Reserved | DNS |
| Fourth IP | AWS | Future use |
| Last IP | Every Network | Broadcasting |

#### Public IP vs Private IP
* Public IP - This is a unique IP @ global level, it comes from AWS Pool or purchased public IPs.
* Private IP - This comes from VPC's range

#### IANA (Internet Assigned Numbers Authority) 
Private IP address ranges are reserved by IANA for internal networking (LANs), not for public internet routing, to prevent address exhaustion. This is an ***obsolete*** way of managing IP address range for private networks   
1. Class A - 1.0.0.0 – 126.255.255.255
2. Class B - 128.0.0.0 – 191.255.255.255 
3. Class C - 192.0.0.0 – 223.255.255.255
4. Class D - 224.0.0.0 – 239.255.255.255
5. Class E - 240.0.0.0 – 255.255.255.255


## Subnets
Subnet is a logical division of VPC. It helps in dividing one large network to many smaller networks, thus called ***Sub***net  
It contains its own CIDR (range of IP addresses) from the parent VPC.  
### NACL
Every Subnet has its own NACL which adds a security layer controlling inbound and outbound traffic @ Subnet level.

## Route Tables
Route tables maintain Routing rules to define outgoing traffic from a Subnet. Any communication from within the subnet is only possible based on the information / rules maintained on the Routing table.  
It is a data file stored in a router or network device that acts as a roadmap for directing data packets to their destinations. It lists known network destinations and the corresponding interfaces or next-hop IP addresses to reach them, operating at Layer 3 of the OSI model.  
#### Note
By default, Route table has a single rule, which is to allows all traffic between all Subnets within the same VPC. As this is the only rule, by default, no internet communication is established for the Subnet. 

## Internet Gateway (IGW)
Internet Gateway is a VPC Component that allows two-way communication between the VPC and the internet supporting both IPv4 and IPv6. This is used as **target** in Route tables for Internet bound routing.

## NAT - Network Address Translation
**NAT** allows one directional traffic. It is used to connect public internet from Private Subnet (which cannot reach internet on its own).  
**NAT** is fully managed by AWS, so its expensive but highly available. 

## VPC Diagram with Components
![VPC Diagram](images/VPC.drawio.svg)

Here, we have a VPC with following components and configuration.
1. One VPC  in Region 1.
2. Then we have three Subnets, one in each AZ. 
3. Each Subnet has 
    1. its NACL that manages to and fro traffic rules. 
    2. Each Subnet has its own Route Table. This determines where the traffic can go from within the Subnet. (Outbound rules)
    3. Each Subnet has multiple resources, each having its own Security Group, which maintains inbound and outbound rules for the specific resources it is applied on.
4. Out of these three Subnets, 
    1. two are Private, which means, they DO NOT have Internet Gateway attached. No information as to how to go out of the VPS.
    2. one Subnet is Public, which means, this does have an IGW attached and resources from this Subnet can reach internet.
5. Lastly, we have a NAT Gateway, placed inside the Public Subnet. This is needed to enable one-way traffic from the resources in our Private Subnet to reach internet to download and update packages.

Based on this, lets see what combinations of Networking calls are possible.
1. All resources inside the VPC **CAN CONNECT** to each other using their Private IPs as the calls within VPC are allowed by default. We can tweak individual Security Group to restrict specific access (as needed)
2. Internet **CAN** reach resources in the Public Subnet as IGW is attached to it. We can block specific ports and IPs (as needed) for individual resources by tweaking the Security Group rules.
3. All resources from the Public Subnet **CAN** also reach the Internet via the IGW.
4. Internet **CANNOT** reach any resource inside the private Subnets. How to SSH into the machine then?
    * We can SSH into a resource on public Subnet and then SSH into the resource on private Subnet. This means we use resource in public Subnet as Jump Server or Bastian Server. 
5. All resources inside the private Subnets **CANNOT** reach the Internet (as their Route tables do not have information to reach IGW). How to upgrade packages then?
    1. We will need to configure a NAT Gateway, which must be placed inside as public Subnet, so that it can reach Internet. It enables one directional traffic from Subnet to Internet. So our resource inside the private Subnet can reach internet via NAT Gateway (after editing Route Table)

#### Note 
1. Multiple Subnets can have a common Route Table, if their network needs are identical.

## Benefits of a VPC
1. Isolation (Security)
2. Every App should be in its VPC.
3. DB and non Web stuff should be in Private Subnets

## VPC Demo on AWS Console.
VPC is Region specific? don't each AZ have its own network? this is confusing.  
Two people can have (will have) same VPC IP range. This is because this is a private IP rang, so multiple devices can have same private IP in diff VPcs. IP address needs to be unique within the VPC.

VPC is Region Level having 
1. a Subnet for each AZ by default.  These Subnets are Public by default (Public Sector).
2. We can create more Subnets if we want.
3. Default Gateway
4. One Route Table for all Subnets (like Room 2 maintaining map for Sector 2 and 3)
    1. Destination as same CIDR of the VPC, traffic allowed. ie. allow local 
    traffic 
    2. 0.0.0.0/0 (internet) -  target = internet gateway

Create VPC
1. VPC Only
2. VPC and More

Create Subnets (use Subnet Calculator if needed)
Create IGW
Create Route Table (default is created with local target on the VPC's CIDR)

What makes a Subnet public or Private. Route Table - If Route table routes Subnet to IGW, Subnet becomes Public.

1. Create EC2 inside private subnet and do not assign public IP
    1. USe its own Security Group, allow SSH and allow http from within VPC
2. Create EC2 inside public subnet and assign public IP
    1. USe its own Security Group, allow SSH and allow http from anywhere

EC2 Public can be reached via browser and ssh. But EC2 private cannot be reached from outside VPC.  
How to connect then?  
SSH into public EC2 and then SSH into private EC2, basically use public EC2 as a jump server / bastian server.
How to update packages in private EC2?  
Note -- We cannot attach IG to the Private Route Table (if we do this, Subnet becomes public). So what do we do? Create NAT Gateway and bind to EC2. This creates one way connection from EC2 to Internet. NAT Gateway needs to be created inside Public Subnet because only Public Subnet can reach Internet.


###### 26<sup>th</sup> April 2026 Puneet Gavri


### NAT Demo
VPC --> NAT Gateway --> Create NAT Gateway
1. Name
2. Availability Mode
    1. Zonal (specify which Subnet we want this NAT in, should be Public). Problem here is that VPC is a regional Service. We may have one Public Subnet in AZ1 and private Subnets in AZ1, AZ2 and AZ3. We can create NAT in AZ1 Public Subnet. Now all EC2 instances from all Private Subnets will go to NAT in AZ1 and then to internet. This will work but we have following issues
        1. Single Point of Failure and additional network transfer charges for cross AZ network transfer. 
    Alternate solution is that we can create one NAT in each AZ and map Route tables from Subnets to NATs on same AZ. Solves both the problems, no single point of failure and no cross AZ network transfer charges. This also has one problem. NATs cannot be stopped (when not used). They are very costly. Solution, regional NAT.
    2. Regional (New)
        1. Choose VPC. It will automatically create a NAT available for all Subnets in our VPC.
3. Connectivity Type (Keep Public)
4. Create NAT
5. Edit Private Subnet's Route Table to connect to NAT Gateway.

#### What is the use of Private Connectivity Type for a NAT.


## VPC Peering

How to connect EC2 from VPC in Region 1 to another EC2 from VPC in Region 2 ?  
VPC Peering Connection between the two VPCs. This can be done across accounts as well. Edit Route Table (add CIDR as Peering Connection). Need to be done on both sides. Must have non-overlapping CIDRs
Notes
1. We can edit CIDR in VPC (a bit complex)
2. VPC to VPC we can only have one peering connection. 
3. VPC Peering setup is free (we only pay for Data flow charges))
4. We cannot peer on-prem network with our public AWS VPC.

## Transit Gateway (TGW)
When we want to establish network between multiple VPCs. It becomes difficult to manage VPC Peering connections. Solution? ***Transit Gateway**  
Transit Gateway (TGW) is a Bridge which follows Hub and Spoke model. So create TGW and attach it to all VPCs that we want to communicate.  
1. **TGW** is fully managed by AWS, we need to ensure configuration. 
2. It is highly scalable. 
3. It is expensive, we pay for setup as well as network data transfer.
4. We can use this to to connect on-prem network to our VPCs by using a VPN tunnel
5. TGW only works within the region ? Google doesn't say so


## Firewalls
We have Firewalls at two level
1. **Security Group** - this is applied at resource level e.g. EC2, Target Group. We have following types of Security Group Rules
    1. **Inbound Rules** - Rules for traffic coming in
        1. We need to specify rules that allow traffic into resource. e.g. TCP Port 80 HTTP, TCP Port 443 HTTPS, TCP Port 22 SSH.
        2. If we do not specify any inbound rule, nothing can reach the resource.
    2. **Outbound Rules** - Rules for traffic going out
        1. By default an Outbound rule is created that allows all traffic out.
        2. We can remove / edit the default rule, if we want to restrict outgoing requests.
    
    **Security Groups are Stateful** i.e. 
    1. The requests that are allowed to come in are also allowed to go out. So we DO NOT need to explicitly create outbound rules for Response Out
    2. The requests that went out are also allowed to come in. So we DO NOT need to explicitly create an inbound rule for Response In.
    3. So in conclusion, we DO NOT need to create any specific rules for Response Out (if the request was allowed in due to inbound rules) and Response In (if the request was allowed to go out from the resource due to an outbound rule)
    5. Security Group only has allow option, anything that is not allowed is denied by default.

2. **NACL** - Network Access Control List - This is a Firewall thats applied at Subnet Level  
NACL als
    1. **Inbound Rules** - Rules for traffic coming in
    2. **Outbound Rules** - Rules for traffic going out

    **NACL is Stateless** It does not maintain state like Security Groups, which means
    1. Traffic in and out is only allowed if it has corresponding Inbound and Outbound rules. 
    2. So we need to explicitly create inbound and outbound rules for Response Out and Response In.
    3. Question - What port do we use for Response Out Outbound rule? (corresponding to incoming HTTP request on Port 80). Note - Source Port can change as browser may randomly choose any available port which will be diff from request to request, specially for different users. This changing Source Port is called Ephemeral port. So we bind an outbound rule for Response Out to ephemeral ports (its a range defined by AWS?)
    4. Due to these complications, it becomes difficult to manage NACL and many applications do not use this and manage all traffic via Security Group.
    5. By default **NACL**allows all traffic in and out.
    6. NACL also have something call RuleNumber. Rules are evaluated from top to bottom (lower number taking higher priority, so the hightest should be deny all). E.g. 
        1. RuleNumber 100 allow all
        2. Rule Number 99 deny request from Asia 

## VPC Flow Log
VPC Flow Logs is a feature that enables you to capture information about the IP traffic going to and from network interfaces in your VPC.Flow log data can be published to the following locations
1. Amazon CloudWatch Logs, 
2. Amazon S3
3. Amazon Data Firehose.


## VPC Endpoint
AWS VPC Endpoints provide private connectivity between a Virtual Private Cloud (VPC) and supported AWS services or VPC endpoint services without requiring an internet gateway, NAT device, or VPN connection.

We have resources that we create inside a VPC, e.g. EC2, Subnet,  Route Tables, ASG, ELB.   
Then we have some that are created outside VPC, S3, Dynamo DB, MarketPlace. These are to be connected via internet.  
So how to connect S3 and Dynamo DB from an instance from Private Subnet? Use NAT Gateway.  
Note(s)
1. Here, we actually do not want to go t internet, only use-case is to go to S3 and Dynamo DB
2. Additionally, we may have a requirement that we cannot have any Public Subnet (which is needed for NAT). How would we solve this?
3. use **VPC EndPoints** This allows u to connect to S3 and DynamoDB without NAT and Internet Gateways. This uses Amazon Backbone Network, does not need Internet.

**VPC Endpoints Types**
1. Gateway Endpoint
    * This is only used for S3 and Dynamo DB
    * Free of cost, so we save money by replacing NAT and IGW with Gateway endpoint.
    * This actualy gets created inside VPC
2. Interface Endpoint
    * This is to be used for all other services (other than S3 and Dynamo DB)
    * An ENI (Elastic Network Interface) gets created inside the Private Subnet where we want to connect services like SQS, SNS, and many more.

### Demo
1. Create a Private EC2 (inside Private Subnet) - this should be able to connect S3 via the VPC Gateway Endpoint
2. Create a Public EC2 (just to use this as a jump server to SSH into our Private Subnet)
3. If we try, aws s3 ls from public EC2, we will get access issue as this EC2 instance cannot connect to s3 yet. Grant IAM policy to our EC2 instance to read. One done we will be able to run the command. This will use IGW to route traffic out from EC2's Security Group to Subnet's NACL to VPC's IGW to Internet to S3.
4. Now load key in public EC2 and SSH into private EC2 instance.
5. Now if we try aws S3 ls from private EC2, this will not even be able to reach S3 (even if we grant the IAM rule) because, it CANNOT reach S3 via Internet as it cannot reach IGW.
6. Solution? - Create a Gateway Endpoint (can only be used for S3 and Dynamo DB). This is created inside a VPC. Edit Private Route Table to be able to reach this Gateway Endpoint. (It gets created by default)
7. Now we will be able to perform aws s3 ls.
8. This can also be used in our Public Ec2 and Public Subnet. This is desired approach as it is free to use.
9. Demo for Interface Endpoint - This does not automatically update Route Table (as it happened for Gateway Endpoint), rather we get a new ENI. This ENI also has a private IP. This can be used to connect internal services including S3 and Dynamo DB (only 1 at  a time based on what was used while creating the endpoint interface).
10. Now we can use aws s3 ls - endpoint {DNS Name}. We can get this DNS Name from the interface endpoint. this should work. This is basically telling aws that run the command and route the traffic via the specific interface endpoint. 
11. Gateway endpoint is free but the interface endpoint is chargeable
12. Private Link is the core technology behind the Interface Endpoints. This creates an ENI or like a private tunnel between out Subnet and the resource we want to use.
13. Lets say we have a Payment Gateway inside some VPC. Multiple EC2 inside a Load Balancer. If we want to connect to it. We create a Private Link (via ENI - interface end point). This first goes to an End Point Service on the Payment Gateway's VPC. there on the request goes to Load Balancer and EC2 to process payment request.


## Virtual Private Network (VPN)
AWS VPN provides secure, encrypted tunnels between on-premises networks and AWS resources (Site-to-Site) or for individual users (Client VPN)  

How our work laptop connects to Org Network? via a VPN. Data flowing through the tunnel is encrypted.

Use-cases of VPN
1.  A website not allowed to be accessed from India, use a VPN to connect to it. But How?


### Types of VPN
1. **Client VPN**  
This is where remote user can connect to a VPC. A VPN tunnel is established between client VPN to orgs VPC. Note - there is only one VPC but multiple VPN tunnels are created (one for each user). We can use bastian host also as an alternate. So to allow a user on the internet to connect to private EC2 instance, we can create VPN between client and VPC where private EC2 resides (or we can give a public Ec2 from where user can jump to private EC2)
2. **Site to Site VPN**
This is where on-prem servers can connect to a cloud VPC. This is also done using a VPN connection between cloud VPC and on-prem network.

### Site to Site VPN Architectures
1. **Single Site to Site VPN Connection**
    1. Customer Gateway - Router at on-prim Site
    2. Virtual Private Gateway - router created at AWS VPC side.
2. **Single Site to Site VPN Connection with Transit Gateway**  
Same region or Multiple Regions (Single Site) with multiple VPCs need to be connected to on-Prem
    1. All VPCs connect to Transit Gateway
    2. This Transit Gateway is then connected to Customer Gateway. 
3. **Multiple Site-To-Site VPN Connection**
Single Region Single VPC connected to multiple on-prem networks
    1. VPC to have Virtual Gateway
    2. This Virtual Gateway is connected to multiple Customer Gateway (one for each on-prem network)
4. **Multiple Site-ToSite VPN Connection with Transit Gateway**
    1. Multiple VPCs on AWS side connected to Transit Gateway
    2. TGW is then connected to multiple Customer Gateway (multiple on-prem network)

VPN is quick to setup and fully managed by AWS, hence it is expensive 
### Limitations on VPN
1. AWS encrypts the data flowing in the tunnel but it flows over the public internet
2. Since public internet is used, latency depends on public internet speed. e.g. downloading large file on work laptop from office network while working from home. 
3. Bandwidth is limited. (Standard tunnel supports 1.25 Gbps)

### Direct Connect
NOTE - Usecase of VPN is have a quick connection between networks. If we want a dedicated bandwidth which should not go via the public internet, we cannot use VPN. What should we use then? **Direct Connect**
1. It offers 100s of Gbps, 
2. Dedicated Channel
3. Physical fibre optic cable is laid out between Site to Site. Thats why this takes time to setup, might take weeks.


### Direct Connect Architecture
1. Multiple VPCs connected via TGW or Single VPC connected via Virtual Private Gateway.
2. Connected to AWS Direct Connect using Direct Connect Router to a Customer Router via the 802.1Q Firbe optic cable. 

https://docs.aws.amazon.com/vpn/latest/s2svpn/Examples.html