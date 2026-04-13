# Linux
###### 14<sup>th</sup> FEb 2026 TA Aarav

Linux is a very powerful Open Source Operating System. It is mode command based and efficient compared to Windows.   
Android Operating System is also created using Linux.

## What is an Operation System
Operating System is an Interface between Users / Apps and the Hardware.  

![Key Features of an Operating System](./images/OperatingSystemKeyFeatures.drawio.svg)

## Why Linux?
1. Linux is faster, more secure, platform independent, Open Source Operating System.
2. Cloud is mainly Linux
3. Best Operating System for Systems (where limited User Interface is needed)

## Who Uses Linux?
1. Tech Companies
2. Developers
3. Super Computers
4. Research Labs
5. Embedded Systems
6. IoT (Internet of Things i.e. Smart Devices)

## History 
Lets look at the History of Programming Languages and Operating Systems.

## Birth of C
1. The C programming language was introduced by Dennis Ritchie at Bell Labs in the early 1970s primarily to develop the Unix
operating system
2. It was designed to address the limitations of existing languages like B and assembly language by providing a balance of low-level
hardware access and high-level, portable programming features.
3. This was basically an interface (intermediatory) between Assembly Level Language and High Level Languag
4. C Language is also portable. can run in any hardware. It became primary programming language to develop Operating System.  

Note -- Before C, we only had Low Level Languages that direcly spoke to the Hardware.

## Birth of UNIX
1. Development of the Unix operating system began in 1969 atAT&T Bell Labs by Ken Thompson and Dennis Ritchie.
2. The first edition (Unix 1st Edition) was released on November 3, 1971, accompanied by the first edition of the Unix Programmer's Manual
3. UNIX is Portable and can run on any type of Hardware because it was built on C and C is Portable.
4. UNIX was NOT Open Source and Users had to buy License. Companies bought UNIX License and enhanced it to work best with therr hardware. Such as
    1. IBM - AIX - Advanced Interactive Executive
    2. HP - UX
    3. Sun Micro Systems - Solaris

![UnixFeatured](images/UNIXFeatures.drawio.svg)

## Birth of Linux
In 1991, Linus Torvalds, only 21 years old, launched a Unix Like OS but kept is free and Open Source.
1. This OS was reliable, Secure and Portable.
2. As this was Open Sourced, it was easier for people to make controlled amends to it and keep improving it.
3. This was mainly Virus Free because of it Open source nature, many users could contribute to fixing vulnerabilities. 
4. Same Key Characteristics as UNIX like
    1. Multi-Tasking
    2. Multi-User
    3. Portable
    4. Kernel - Shell - User Model
    5. Hierarchial File System
    6. Name Spaces -- Very IMP 

### Linux Distributions
1. Debian -- General Purpose, can be used everywhere (including embedded system, stable, oldest)
2. Ubuntu -- Desktop friendly distribution. Created on top of Debian. Beginner friendly
3. RedHat Enterprise Linux -- RHEL -- Enterprise grade distribution. Commercial grade. Paid version
4. Fedora -- Cutting edge distribution. Latest software and features appear here first. Sponsored by RHEL
5. Kali Linux -- Security focused distribution used for testing security. Preloaded with security related features. Mainly used by Ethical Hackers.
6. Centos -- Community Linux derived from RHEL. Free version of RHEL.
7. Amazon Linux -- Optimized for AWS

## Basic Linux Commands
We can try out these commands in any Linux System e.g. WSL on Windows, or actual Linux System or online [@KllrCoda](https://killercoda.com/playgrounds)

### pwd
Prints the working directory where the command is being run.
```
root@ubuntu:~$ pwd
/root
root@ubuntu:~$ 
```

### ls
Prints the Contents of the current Directory
We can use many options along with this command. some of the most used options are
* -l : This prints all files and folders in a list format
* -a : This prints all files, including hidden files (files starting with .)
* -r : Sort order is reversed to descending instead of ascending 
* -t : Sort by time (default is name)
* -s : print allocated size of each file
* -S : Sort by Size (largest first)

We can combine these options in any order to apply multiple options. E.g shown below
```
root@ubuntu:~$ ls -lart
total 52
-rw-r--r--  1 root root  161 Apr 22  2024 .profile
-rw-------  1 root root   10 Feb 10  2025 .bash_history
drwx------  2 root root 4096 Apr  1 08:10 .ssh
drwxr-xr-x 22 root root 4096 Apr  1 08:11 ..
lrwxrwxrwx  1 root root    1 Apr  1 08:11 filesystem -> /
-rw-r--r--  1 root root  109 Apr  1 08:11 .vimrc
-rw-r--r--  1 root root 3234 Apr  1 08:11 .bashrc
-rw-r--r--  1 root root  165 Apr  1 08:11 .wget-hsts
drwxr-xr-x  4 root root 4096 Apr 13 01:58 .theia
drwxr-xr-x  2 root root 4096 Apr 13 01:58 MyLinuxDirectory2
drwxr-xr-x  2 root root 4096 Apr 13 01:58 MyLinuxDirectory4
drwxr-xr-x  2 root root 4096 Apr 13 01:58 MyLinuxDirectory3
drwx------  8 root root 4096 Apr 13 01:58 .
drwxr-xr-x  3 root root 4096 Apr 13 02:05 MyLinuxDirectory1
root@ubuntu:~$ 
```

### mkdir
Creates a new Directory (if not present). We can supply multiple directory names and the command will create all directories.
```
root@ubuntu:~$ mkdir MyLinuxDirectory1 MyLinuxDirectory2
root@ubuntu:~$ ls -lrt
total 8
lrwxrwxrwx 1 root root    1 Apr  1 08:11 filesystem -> /
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory2
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory1
root@ubuntu:~$ mkdir MyLinuxDirectory1 MyLinuxDirectory3 MyLinuxDirectory4
mkdir: cannot create directory 'MyLinuxDirectory1': File exists
root@ubuntu:~$ ls -lrt
total 16
lrwxrwxrwx 1 root root    1 Apr  1 08:11 filesystem -> /
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory2
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory1
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory4
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory3
root@ubuntu:~$ 
```

### cd
Change Directory. Use this to change working directory
We can use cd
``` linux
root@ubuntu:~$ ls -lrt
total 16
lrwxrwxrwx 1 root root    1 Apr  1 08:11 filesystem -> /
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory2
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory1
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory4
drwxr-xr-x 2 root root 4096 Apr 13 02:11 MyLinuxDirectory3
root@ubuntu:~$ cd MyLinuxDirectory1
root@ubuntu:~/MyLinuxDirectory1$ pwd
/root/MyLinuxDirectory1
root@ubuntu:~/MyLinuxDirectory1$ cd ../MyLinuxDirectory2
root@ubuntu:~/MyLinuxDirectory2$ mkdir MyNewDir
root@ubuntu:~/MyLinuxDirectory2$ cd MyNewDir
root@ubuntu:~/MyLinuxDirectory2/MyNewDir$ pwd
/root/MyLinuxDirectory2/MyNewDir
root@ubuntu:~/MyLinuxDirectory2/MyNewDir$ cd
root@ubuntu:~$ pwd
/root
root@ubuntu:~$ 
```

### touch
This helps us create file(s) in the working directory
```
root@ubuntu:~/MyLinuxDirectory1$ ls -lrt
total 4
drwxr-xr-x 2 root root 4096 Apr 13 02:01 MyNewDir
root@ubuntu:~/MyLinuxDirectory1$ touch file1.txt file2.txt
root@ubuntu:~/MyLinuxDirectory1$ ls -lrt
total 4
drwxr-xr-x 2 root root 4096 Apr 13 02:01 MyNewDir
-rw-r--r-- 1 root root    0 Apr 13 02:05 file2.txt
-rw-r--r-- 1 root root    0 Apr 13 02:05 file1.txt
root@ubuntu:~/MyLinuxDirectory1$ 
```

### nano
GNU nano is a beginner-friendly, modeless command-line text editor for Unix-like systems, widely used for quick edits and configuration management.
It creates file in the working directory if it does not exists
```
root@ubuntu:~/MyLinuxDirectory1$ ls -lrt
total 0
root@ubuntu:~/MyLinuxDirectory1$ nano file.txt
root@ubuntu:~/MyLinuxDirectory1$ cat file.txt
Hi This is my file
root@ubuntu:~/MyLinuxDirectory1$ 
```
In above example, non file was edited on the nano editor. to save the file, press Control + S and to exit Control + X. To exit without Saving, press Control + X. User is prompted to save changes or not. choose Y for Yes and N for no.

### vi /vim
vi is a mode based file editor. It has following basic modes
1. Command Mode - This is the default mode when opened. Every Keystroke is interpreted as a command. e.g i for coming to edit mode, x to delete character at cursor or dd to delete entire line, move, etc
2. Insert Mode : This is the mode for typing, to get to this mode, press i. Press escape to go back to command mode.
3. Last line (Ex) Mode : Used for saving or quitting. Press : from command mode to access. w! to save, wq! to save and quit, q! to quit without saving 
```
root@ubuntu:~/MyLinuxDirectory1$ vi file.txt
root@ubuntu:~/MyLinuxDirectory1$ cat file.txt
Hi This is my file
I have added this line using vi editor
root@ubuntu:~/MyLinuxDirectory1$ 
```

### cat
Already seen in previous example, cat command is used to display contents of a file.
We can also use cat to concatenate data of multiples files
```
root@ubuntu:~/MyLinuxDirectory1$ nano file2.txt
root@ubuntu:~/MyLinuxDirectory1$ cat file.txt file2.txt
Hi This is my file
I have added this line using vi editor

This is my file 2
root@ubuntu:~/MyLinuxDirectory1$ 
```

### clear
Use this to clear the command window.
```
clear
```
