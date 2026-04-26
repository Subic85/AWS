# Linux Basics
###### 14<sup>th</sup> and 15<sup>th</sup> Feb 2026 - TA Aarav

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
This is **Print Working Directory** command which is used to print the working directory.
```
root@ubuntu:~$ pwd
/root
root@ubuntu:~$ 
```

### ls
This is **List** command used to print the Contents of the current Directory
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
This is **Makr-Directory** command uses to creates a new Directory (if not present). We can supply multiple directory names and the command will create all directories.
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
This is **Change-Directory** command used to change the working directory
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
The **touch** command helps us to create empty file(s) in the working directory. We can also use this to update timestamps on a file like last accessed, last modified.
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
**GNU nano*** is a beginner-friendly, modeless command-line text editor for Unix-like systems, widely used for quick edits and configuration management.
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

### vi / vim
**VI = Visual-Imitation** is a mode based visual file editor. This was later improved to **VIM = Visual Imitation Improved**. It has following basic modes
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
**Concatenate** command is used to concatenate contents of files. It has following use-cases
1. Display content of a Single file
2. Concatenate contents of multiple files and display on console. 
3. Create a new file with some content supplied with the command. 
4. Append some text to the end of an existing file 
```
root@ubuntu:~$ ls -lrt
total 0
lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
root@ubuntu:~$ cat > file1.txt
This is the content i am tying on multiple lines.        
And final I will press control and D to save the content in the file
root@ubuntu:~$ cat file1.txt
This is the content i am tying on multiple lines.        
And final I will press control and D to save the content in the file
root@ubuntu:~$ cat >> file1.txt
Now I am appending this text at the end of the file
root@ubuntu:~$ cat file1.txt
This is the content i am tying on multiple lines.        
And final I will press control and D to save the content in the file
Now I am appending this text at the end of the file
root@ubuntu:~$ cat > file2.txt
This is my file2
root@ubuntu:~$ cat file1.txt file2.txt
This is the content i am tying on multiple lines.        
And final I will press control and D to save the content in the file
Now I am appending this text at the end of the file
This is my file2
root@ubuntu:~$ 
```

### clear
This is **Clear** command used to clear the command window.
```
clear
```

### cp 
This is **Copy** command used for Copying file from one directory to other, like Window's Copy-Paste.  
We can rename the file while in the destination table.  
Source and destination can be in the same directory but in that case name should be different
```
root@ubuntu:~/dir1$ ls -lrt
total 0
-rw-r--r-- 1 root root 0 Apr 14 00:05 file1.txt
-rw-r--r-- 1 root root 0 Apr 14 00:05 file2.txt
root@ubuntu:~/dir1$ cp file1.txt file3.txt
root@ubuntu:~/dir1$ ls -lrt
total 0
-rw-r--r-- 1 root root 0 Apr 14 00:05 file1.txt
-rw-r--r-- 1 root root 0 Apr 14 00:05 file2.txt
-rw-r--r-- 1 root root 0 Apr 14 00:06 file3.txt
root@ubuntu:~/dir1$ cp file3.txt ../dir2
root@ubuntu:~/dir1$ cp file2.txt ../dir2/renamedfile2.txt
root@ubuntu:~/dir1$ cd ../dir2
root@ubuntu:~/dir2$ ls -lrt
total 0
-rw-r--r-- 1 root root 0 Apr 14 00:07 file3.txt
-rw-r--r-- 1 root root 0 Apr 14 00:07 renamedfile2.txt
root@ubuntu:~/dir2$ 
```

### mv
This is **Move** command used for moving file from one directory to another, its like Window's Cut-Paste.  
We can rename the file while in the destination table.  
Source and destination can be in the same directory but in that case name should be different. This use-case is to rename a file in the same directory
```
root@ubuntu:~/dir1$ ls -lrt
total 0
root@ubuntu:~/dir1$ cd ../dir2
root@ubuntu:~/dir2$ ls -lrt
total 0
root@ubuntu:~/dir2$ touch file1.txt
root@ubuntu:~/dir2$ mv file1.txt file2.txt
root@ubuntu:~/dir2$ ls -lrt
total 0
-rw-r--r-- 1 root root 0 Apr 14 00:12 file2.txt
root@ubuntu:~/dir2$ mv file2.txt ../dir2
mv: 'file2.txt' and '../dir2/file2.txt' are the same file
root@ubuntu:~/dir2$ mv file2.txt ../dir1
root@ubuntu:~/dir2$ ls -lrt
total 0
root@ubuntu:~/dir2$ cd ../dir1
root@ubuntu:~/dir1$ ls -lrt
total 0
-rw-r--r-- 1 root root 0 Apr 14 00:12 file2.txt
root@ubuntu:~/dir1$ mv file2.txt ../dir2/file3.txt
root@ubuntu:~/dir1$ cd ../dir2
root@ubuntu:~/dir2$ ls -lrt
total 0
-rw-r--r-- 1 root root 0 Apr 14 00:12 file3.txt
root@ubuntu:~/dir2$ 
```

### rmdir
**Remove-Directory** command can be used to remove empty directories. 
```
root@ubuntu:~/dir2$ ls -lrt
total 0
-rw-r--r-- 1 root root 0 Apr 14 00:12 file3.txt
root@ubuntu:~/dir2$ cd .. 
root@ubuntu:~$ rmdir dir2
rmdir: failed to remove 'dir2': Directory not empty
root@ubuntu:~$ rm dir2/file3.txt
root@ubuntu:~$ rmdir dir2
root@ubuntu:~$ ls -lrt
total 4
lrwxrwxrwx 1 root root    1 Apr  1 08:11 filesystem -> /
drwxr-xr-x 2 root root 4096 Apr 14 00:13 dir1
root@ubuntu:~$ 
```

### rm
**Remove** command is used to remove files and directories. Some frequently used options with this command.
* -r: Use this to recursively delete the sub directory and files
* -f: force
* -v: Verbose
* -i: Prompt before every removal
```
root@ubuntu:~/dir1/dir2/dir3/dir4$ ls -lrt
total 0
-rw-r--r-- 1 root root 0 Apr 14 00:22 ile2.txt
-rw-r--r-- 1 root root 0 Apr 14 00:22 file1.txt
root@ubuntu:~/dir1/dir2/dir3/dir4$ cd
root@ubuntu:~$ rm dir1
rm: cannot remove 'dir1': Is a directory
root@ubuntu:~$ rm dir1 -r
root@ubuntu:~$ ls -lrt
total 0
lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
root@ubuntu:~$ 
```

### hardlink and softlink
Hard links and soft links (symbolic links) are two ways to reference files on a storage device, but they operate differently at the file system level.  
| Feature | HardLink | SoftLink |
| :-----: | :------ | :------ |
| How files are created?    | This creates another file and both point to the same inode number. Think of this as two reference type variables pointing to same memory location| This creates a new file, has its own inode number but points to the original file  |
| Deletion of Linked File | Deleting linked file(s) will not change the original file. |Deleting linked file(s) will not change the original file. |
| Deletion of Original File | Deleting linked file(s) will not delete the data, its just like two files pointing to same data but now only one file is pointing to that data | Deleting original file deletes the data and now the linked files(s) are dangling (pointing to orphan location) |
| File System | All hard linked files must reside on the same partition | No such requirement for Soft linked files, they can cross boundaries and link to different partitions  |
| Directories | We cannot hard link directories | We can create soft link for directories  |
| Storage Size | Shows same size as original file but does not consumer additional space | Shows negligible size (to keep the path of the original file) |
| Use-Case | Data Resiliency and Mirroring. Always recommended to keep hard links of important files in backup directories, prevents data loss in case of accidental deletion.  | Shortcut to original files or directories|

**HardLink**
```
root@ubuntu:~$ mkdir dir1
root@ubuntu:~$ cd dir1
root@ubuntu:~/dir1$ nano file1.txt
root@ubuntu:~/dir1$ cat file1.txt
This is File1 in dir1.
root@ubuntu:~/dir1$ ln file1.txt file2.txt
root@ubuntu:~/dir1$ ls -lrt
total 8
-rw-r--r-- 2 root root 23 Apr 14 00:33 file2.txt
-rw-r--r-- 2 root root 23 Apr 14 00:33 file1.txt
root@ubuntu:~/dir1$ cat file1.txt file2.txt
This is File1 in dir1.
This is File1 in dir1.
root@ubuntu:~/dir1$ rm file1.txt
root@ubuntu:~/dir1$ ls -lrt
total 4
-rw-r--r-- 1 root root 23 Apr 14 00:33 file2.txt
root@ubuntu:~/dir1$ cat file2.txt
This is File1 in dir1.
root@ubuntu:~/dir1$ 
```

**SoftLink**
```
root@ubuntu:~/dir1$ ls -lrt
total 0
root@ubuntu:~/dir1$ nano file1.txt
root@ubuntu:~/dir1$ ln -s file1.txt file2.txt
root@ubuntu:~/dir1$ ls -lrt
total 4
-rw-r--r-- 1 root root 22 Apr 14 00:37 file1.txt
lrwxrwxrwx 1 root root  9 Apr 14 00:38 file2.txt -> file1.txt
root@ubuntu:~/dir1$ cat file1.txt file2.txt
This is file1 in dir1
This is file1 in dir1
root@ubuntu:~/dir1$ rm file1.txt
root@ubuntu:~/dir1$ ls -lrt
total 0
lrwxrwxrwx 1 root root 9 Apr 14 00:38 file2.txt -> file1.txt
root@ubuntu:~/dir1$ cat file2.txt
cat: file2.txt: No such file or directory
root@ubuntu:~/dir1$ 
```

### chmod
This **Change-Mode** command is used to manage and modify the access permissions of files and directories. It basically helps us define which **Users, Groups and Others** can **Read, Write and Execute** the files and Directories.  
Lets look at the first column of the **ls -lrt** output. It looks something like **-rw-r--r--**. Lets dissect this into three sections after the first hyphen(-). We see **rw-**, **r--** and **r--**.
1. **U**-User : First  three characters are for User, in this case owner who created the file. 
2. **G**-Group : Send three characters are for Group. We can create Groups and assign multiple users in that group and provide access at group level so that all users can be granted or revoked access easily.
3. **O**-Others : Last three characters are for Others, basically neither the Owner of the file or nor a User that is part of Group. Some Other user

Now, each section also has three character representation. Here,
1. **Read** - First character is for read. If **U, G or O** have read access, we will see **r** else we will see **-**.
2. **Write** - Second character is for Write. If **U, G or O** have write access, we will see **w** else we will see **-**.
2. **Execute** - Second character is for Write. If **U, G or O** have execute access, we will see **x** else we will see **-**.

💡How to assign or modify access. We have two ways of doing it
1. Numerical Method (Octal).  
Each permission is assigned a number
    1. 4 = Read
    2. 2 = Write
    3. 1 = Execute  

    We can sum up these numbers and assign then to **U, G or O**.  
    Lets see with an example. Lets say we want to grant Read, Write and Execute (4 + 2 + 1) to Owner, Read and Write (4 + 2) to Group and only Read to Others (4). We can run **chmod 764 file1.txt**
    ``` 
    root@ubuntu:~$ ls -lrt
    total 0
    lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
    root@ubuntu:~$ touch file1.txt
    root@ubuntu:~$ ls -lrt
    total 0
    lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
    -rw-r--r-- 1 root root 0 Apr 14 01:47 file1.txt
    root@ubuntu:~$ chmod 764 file1.txt
    root@ubuntu:~$ ls -lrt
    total 0
    lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
    -rwxrw-r-- 1 root root 0 Apr 14 01:47 file1.txt
    root@ubuntu:~$ 
    ```
2. Symbolic (Letters)  
This can ebe used to add (+), remove(-) or explicitly set (=) permissions. Examples below
    1. **chmod g+X file1.txt** - this will add Execute permissions to group users.
    2. **chmod +r file1.txt** - this will add Read permissions to **All** three - **U, G or O**
    3. **chmod u=rwx,g=rw,o=r** - this will add Read, Write and Execute to U, Read and Write to Group and only Read to Others.
    4. **chmod u=rwx,go=rw** - this will add Read, Write and Execute to U, Read and Write to Group and Others.
    ```
    root@ubuntu:~$ ls -lrt
    total 0
    lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
    root@ubuntu:~$ touch file1.txt
    root@ubuntu:~$ ls -lrt
    total 0
    lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
    -rw-r--r-- 1 root root 0 Apr 14 01:54 file1.txt
    root@ubuntu:~$ chmod u+x file1.txt 
    root@ubuntu:~$ ls -lrt
    total 0
    lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
    -rwxr--r-- 1 root root 0 Apr 14 01:54 file1.txt
    root@ubuntu:~$ chmod go=rw file1.txt 
    root@ubuntu:~$ ls -lrt
    total 0
    lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
    -rwxrw-rw- 1 root root 0 Apr 14 01:54 file1.txt
    root@ubuntu:~$ chmod -wx file1.txt
    chmod: file1.txt: new permissions are r--rw-rw-, not r--r--r--
    root@ubuntu:~$ ls -lrt
    total 0
    lrwxrwxrwx 1 root root 1 Apr  1 08:11 filesystem -> /
    -r--rw-rw- 1 root root 0 Apr 14 01:54 file1.txt
    root@ubuntu:~$ 
    ```

### grep


### ps1

### echo

### printf

### history

### su

### ps

### kill / pkill

### ip addr show

### tail ?

### sha1sum

### stress