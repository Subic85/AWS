# CloudTrail and CloudWatch
###### 18<sup>th</sup> April 2026 Puneet Gavri

## CloudTrail
AWS CloudTrail is a governance and auditing service that records user activity and API calls across AWS infrastructure. It is event based metric e.g. who stopped EC2 instance, root login, etc. It enables security analysis, resource change tracking, and compliance auditing by logging actions from the console, SDKs, and CLI. Key features include 90-day free event history, S3 log storage, and CloudTrail Lake for audit data analysis.
We can forward the log to CloudWatch where these logs will be maintained for as long as we want


## CloudWatch
CloudWatch is a Monitoring Service in AWS that monitors every resource in AWS. e.g. CPU Utilization, RAM Utilization, IOPS, ThroughPut, etc. This is available by default. It can be accessed via
1. CloudWatch --> Metric --> Choose Service --> Choose Resource.
2. Directly available in the Monitoring section on the Resource page. 
3. Logs

### Demo (Create an Alarm if EC2 CPU goes above 60%)
CloutWatch-->Alarms-->Create Alarm

1. Specify metric and conditions
2. ConfigureSection  
    1. AlarmState
        1. InAlarm
        2. OK
        3. Insufficient Data
    2. Send Notification to following SNS (Topics with Pub/Sub) Topic
        1. Select Existing Topic
        2. Create new Topic
            1. Supply new topic name and 
            2. add emails ids that subscribe to the new topic.
        3. Use topic ARN to notify other accounts. 
    3. Action
        1. Reboot, etc
3.  Add Alarm Details
    1. Name and Desc
    2. Description (md format)
4. Review and Create


### Custom Metrics.
Custom Metrics and / or Alerting needed based on Application Log.
Lets say EC2 instance logging app logs (debug, info, etc). We can generate metrics based on certain patterns. e.g.  
- If we get UnAuth message in the log file more than 10 times
- When specific User Logs in.  

How can this be done? Metrics are generated on Cloud Watch, so first, we need to ensure our logs are being copied to CloudWatch.  
Lets do this by first creating a new Role that will grant EC2 access to write to CloudWatch..  
- IAM --> Create a Role --> AWS Service --> EC2 --> CloudWatchLogsFullAccess  
- Specific Ec2 Instance --> Modify Iam Role --> Choose your new Role  
- Download CloudWatch Agent Package to your EC2 instance. (Check commands online)
- Verify agent got installed correctly
- Run Config Wizard on EC2 instance
    - Which OS are we planning to run the agent (choose OS)
    - Are you using Ec2 or On-Prem (we can do on-Prem as well !!!)
    - Which user to run the agent (choose user)
    - StatsD daemon? - This is a BG that collects metrics
    - which port 
    - frequency 
    - aggregate?
    - CollectD?
    - hot metrics (CPU, RAM)
    - metrics per core level?
    - ec2 dimensions 
    - many more
- go to bin directory to verify/modify config
- run command to start cloud watch agent.

Logs will get directed to Cloud Watch. Now go to Cloud Watch and create a Metric based on the Log. e.g. 404 

##### Note(s) -  
1. for EC2, out of the box, we have very limited metrics, nothing related to DISC, Memory. We are to use Custom Metrics to get these.

## Cloud Watch Widgets
Allows us to add some widgets on CloudWatch dashboard to show metrics of interested resources. May diff chart types are available

## Cloud Watch Operations + Many other features (Check Console) 

## CloudWatch Vs CloudTrail
CloudWatch monitors performance and resource health (what is happening), while CloudTrail logs API activity for auditing and security compliance (who did what). CloudWatch acts in real-time with metrics and alarms, whereas CloudTrail provides a historical record of events.

