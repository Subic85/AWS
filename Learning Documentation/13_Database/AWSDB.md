# AWS Databases
###### 9<sup>th</sup> Mar 2026 - Puneet Gavri

## Database Types
Relational databases (SQL) use structured, table-based models (rows/columns) with rigid schemas and high ACID compliance, ideal for transactional data. Non-relational databases (NoSQL) offer flexible, document, graph, or key-value structures, designed for unstructured data, horizontal scaling, and high-performance, rapid development


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