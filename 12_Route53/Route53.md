# Route53
###### 19<sup>th</sup> April 2026 Puneet Gavri (Before break)

Route53 is **Scalable DNS and Domain Name Registration**

When we hit Yahoo.com on browser, it needs the IP address of yahoo.com to hit. So it first goes to a DNS resolver that brings the IP address mapped to yahoo.com.

## DNS Resolution 
Process of resolving DNS Name to IP Address by the DNS  Resolver is called DNS Resolution.  
How this happens in Background?  
User types, abc.com on browser and hits enter. Browser will perform following steps till it finds IP.
1. Look locally (on the device), if not found
2. Check with Internet Service Provider's DNS Resolver. (e.g. Rogers DNS Resolver).
3. If not found locally, DNS Resolver will go to Root Name Server with the TLD (.com, .ca, etc)
4. Root Name Server will direct it to the Name Server based on TLD (.com, .ca, etc)
5. Name Server will then provide Registrar's IP Address. 
6. Registrar will then resolve the Domain Name (including the SubDomain) to an Application's IP Address.
4. Internet Service Provider's DNS resolver will then pass the IP Address to the browser.  

Additionally, DNS Resolver will cache the IP for future use (or for another User / Browser). Cache time is defined by the Domain Registrar and its called TTL (Time To Live).  

## DNS Registrar
We buy domains from Domain Registrars like godaddy.com, domain.com, hostinger.com, etc. These then register the Domain on the internet so that any browser asking for our domain can be routed to our choice of IP.

## AWS Route 53
This does both, its a DNS Resolver as well as Registrar

## Domain Components
1. Root - Its hidden to us, we don't see. it comes after *.com, *.org, etc. Root Named Server manages information all Name Server Websites based on the TLD. e.g. Resolver for all websites ending in .com, .ca, etc
2. TLD - Top Level Domain - e.g. .com, .ca, .in, .org
3. Domain - yahoo in yahoo.com is the Domain. Also called Second-Level Domain
4. SubDomain - main in mail.yahoo.com is a SubDomain.
5. Protocol (Scheme) - Http / HTTPS
6. Port - Port Number to hit when calling server
7. Path - Additional path after TLD e.g. /menu/accessories
8. QueryString - e.g. ?pid=123&qty=3


## Hosted Zone
For DNS Resolution by Route 53, create a Hosted Zone.  
Start by first providing the Domain e.g. abc.com  

### Type
1. Public Hosted Zone (Public facing)
2. Private Hosted Zone (Internal to a private network e.g. Office Intranet). We don't need to purchase public domain for this. Domain should still be unique on our VPC. 

### Records
This is what maps Domain/SubDomain to an IP Address. Two records are created by default in a HostedZone. One is NS type and other is SOA. These are unique and should not be touched? 

#### DNS Record Types
1. A - Maps to IPv4 Address(s). Route 53 can, allows us to map to ALB URL
2. AAAA - Maps to IPv6 Address(s)
3. CNAME (Canonical Name) -  Forwards one domain or subdomain to another domain rather than an IP address.
4. CAA -  Specifies which certificate authorities are allowed to issue SSL/TLS certificates for the domain
5. NS - Named Servers for the Hosted Zone
6. SOA - Contains crucial administrative information about the domain, including when it was last updated.
7. MX - Main Server URL
8. Its a Long List

### Routing Policy
1. Simple (One to One Mapping)
2. Weighted. We can have multiple IPs (end points) and define weight for each end point
3. Geo Location. Routing of Users based on their Geo Location (could be compliance related also)
4. Latency. Routing based on lowest latency
5. Failover - Failover to another Region. Health Check needs to be defined.

## Demo 1
Steps
1. Create 3 EC2 instances.
2. Create a Private Hosted Zone with A record to our IP(s) for one of our sub domains. 
3. Login to console of any instance and run CURL command to our subdomain. 

## Demo 2
Steps
1. Create 3 EC2 instances behind an ALB (optional behind an ASG).
2. Create a Private Hosted Zone with A record to our ALB. 
3. Login to console of any instance and run CURL command to our subdomain. 


When we try to resolve Private Hosted Zone from within AWS, request goes to  VPC which has its own DNS Resolver (on port 53). And it detects its internal, it directly goes to Route53 (so things do not go public resolvers over the internet)

Pricing - 
- Hosted Zones are not charged in the first 12 hours. 
- DNS queries are charged for each resolution.
- Routing Policy also determines the cost
- Routing to Alias (internal AWS resource like ALB) is not charged

Question - 
ALB allows us to route based on Path and Route 53 allows us to route based on SubDomains + these other Routing Policies. Can we explain a real world case where we use both in conjunction 

