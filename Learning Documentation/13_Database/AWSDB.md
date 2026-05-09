# AWS Databases
###### 9<sup>th</sup> Mar 2026 - Puneet Gavri

## Database Types
Relational databases (SQL) use structured, table-based models (rows/columns) with rigid schemas and high ACID compliance, ideal for transactional data. Non-relational databases (NoSQL) offer flexible, document, graph, or key-value structures, designed for unstructured data, horizontal scaling, and high-performance, rapid development  

Database Services come under **PaaS** - so DB infrastructure is managed by AWS. We manage the data flow. If we want full control over the DB, we can create an EC2 and install the DB engine of our choice, this was we can manage DB infrastructure (if that is our use case).


### Relational DB
1. Amazon RDS
    1. MySQL
    2. PostgreSQL
    3. MariaDB
    4. Oracle
    5. SQL Server
2. Amazon Aurora

### Non-Relational
| Database | Data Model | Primary Use case |
| -------- | ---------- | ---------------- |
| DynamoDB | Key-Value / Document | High-scale web apps, mobile backends |
| DocumentDB | Document | Content management, user profiles |
| ElastiCache | In-Memory | High-speed caching, real-time analytics |
| Neptune | Graph | Knowledge graphs, fraud detection |
| Keyspaces | Wide-Column | High-throughput industrial logs |
| Timestream | Time Series | IoT data, devops metrics |

## RDS Create Options
Aurora and RDS --> Create Database --> Full Configuration
1. Engine Type
    1. Aurora (MySQL Compatible)
    2. Aurora (MySQL Compatible)
2. Choose a 
    1. Full Option
    2. Easy Create
3. Template
    1. Prod
    2. DEV / QA
    3. Free Tier
4. Availability and Durability
    1. Single AZ-DB Instance : Instance gets created in a Single AZ.
        1. AWS creates an EC2 instance and installs the DB Engine. We can run our DDL and DML queries.
        2. This is risky due to single point of failure.
    2. Multi AZ DB Instance : Here, we get 2 instances, each in different AZ.
        1. AWS creates two EC2 instance (in different AZs) and installs the DB Engine. 
        2. One EC2 is primary and other one is Secondary. 
        3. All Queries (DDL and DML) are run on Primary.
        4. Replication from Primary to Secondary happens in RealTime (synchronous)
        5. When Primary goes down, requests are sent to Secondary and Secondary becomes Primary and a new Secondary instance is created (AWS Managed). 
    3. Multi AZ-DB Cluster. Here, we get 2 instances, each in different AZ.
        1. AWS creates three EC2 instance (in different AZs) and installs the DB Engine.
        2. One EC2 is primary and other ones are Secondary.
        3. All Queries (DDL and DML) are run on Primary.
        4. Replication from Primary to Secondary happens in RealTime (synchronous?)
        5. Secondary DBs are not just sitting idle, they are used as read replicas. 
        6. All are on SSD (better performant)

    ![Availability and Durability](images/RDS_Availability.svg)
5. Settings
   1. Engine (MySql,  version)
   2. DB Instance Identifier
   3. Credentials
   4. Authentication Options
       1. Password
       2. IAM
   5. Instance Type and Size
   6. Storage Type (Uses EBS Volume) and Size
   7. Auto Scaling
   8. Maximum Storage Threshold (Max Size)
6. Connectivity 
   1. VPC
   2. Subnet
   3. Security Group
7. Monitoring
8. Additional Configuration
   1. Log Export
9. Parameter Group
10. Backup (Snapshot as its EBS)
11. Enable auto minor version upgrade (choose window).

### Parameter Group
We can use this to configure default settings, e.g TimeZone, Default Connection Timeout. Note, Parameter Group is to be used while creating of DB

