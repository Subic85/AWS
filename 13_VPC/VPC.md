# VPC - Virtual Private Cloud
###### 25<sup>th</sup> April 2026 Puneet Gavri

AWS VPC is a foundational AWS service that allows us to create an isolated Network where we can create our resources like EC2 instances, RDS databases, etc. It provides full control over following networking assets to customize network configuration similar to traditional Data Center.
1. IP Addresses
2. Subnets
3. Routes Tables
4. Network gateways and many more.

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
NAT allows one directional traffic. It is used to connect public internet from Private Subnet (which cannot reach internet on its own).

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
VPC Peering Connection between the two VPCs. This can be done across accounts as well. Edit Route Table (add CIDR as Peering Connection). Need to be done on both sides. CIDRs must be different
Notes
1. We can edit CIDR in VPC (a bit complex)
2. VPC to VPC we can only have one peering connection. 
3. What if we have many VPCs. It becomes very difficult to maintain peering Connections across VPC, Solution. Transit Gateway
4. Transit Gateway (TGW). This is like a Bridge (Hub and Spoke). So create TGW and attach all VPCs to TGW and they can all communicate. 