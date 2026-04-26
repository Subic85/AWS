# Python Basics
###### 21<sup>st</sup> Feb 2026, 22<sup>nd</sup> Feb 2026, 28<sup>th</sup> Feb 2026 - TA Ananya and 1<sup>st</sup> Mar 2026 - TA Vansh

Python was invented in 1991 by Guido Van Rosum (35 years old then) and its named after his favorite show Python's flying circus.

## Why Python?
1. Python is a beginner friendly language
2. It has large library domain (including ENgineering Mathematics)
3. Its a High Level Language (similar to C# and Java)
4. Python is interpreter based language which means HighLevel code is translated to MachineLevel at run time, rather than being pre-compiled.
5. Python is a case sensitive language.
 
### Where to run our Python code?
1. Install Anaconda
    - Install URL - https://www.anaconda.com/download/success
	- Install Jupiter Notebook
	- Jupiter kernel
2. Run in Visual Studio Code
3. For small samples, we can use Google Colab online

#### Jupiter Notebook Vs VSCode
- Use VS Code when building applications, scripts, or working on large projects with multiple files
- Use Jupiter Notebook for Data Analysis, ML or Scientific research where we want to see see outputs (like graph) immediately after each small block of code.

##### Note
Content of Python Basic during the course - https://colab.research.google.com/drive/1N6IHEoRocfEagtsF6_Pti2s67cDx9e6o?usp=sharing

## Variables
``` py
# Here x is a variable holding value 9.
# Variables are not type coupled in Python so type definition not needed
# Data Type can be changed 
x = 9
print(x)
x = 10.5
print(x)
```
``` py
#Output
9
10.5
```
#### Variable Declaration Rules
1. Rules for variable declaration
2. should not start with number
3. can start with _ or alphabet
4. should not have whitespaces
5. should not be key words (we have 32 keywords in python)

## Data Types 
Data types in python defines the kind of values variable can hold. We can use type function to determine the data type of a variable. We have following built-in Data Types in Python

### int
``` py
i = 10
print(i) 
print(type(i)) 
```
```
# Output
10
<class 'int'>
```

### float
``` py
i = 10.5
print(i) 
print(type(i)) 
```
```
# Output
10.5
<class 'float'>
```

### string
Anything stored between single or double quotes is a string
``` py
i = "Subodh"
print(i) 
print(type(i)) 

multiLineString = """This is how
we can write multiline 
string in Python"""
print(multiLineString)
print(type(multiLineString))

```
```
# Output
Subodh
<class 'str'>

This is how
we can wrtie multiline 
string in Python
<class 'str'>
```

### bool
``` py
i = True
print(i) 
print(type(i)) 
```
```
# Output
True
<class 'bool'>
```

## Type Casting
Type casting is when we change the type of a variable before using it for purposes like assignments, printing, etc.  
We have two types of Type Casting
1. Implicit Type Casting  
This is when interpreter does it on its own, where we dont specify anything
``` py
a = 10
b = 10.5
c = a + b #this is 20.5, python automatically converts a to float and then adds to b and then stores in c (which is also float).
``` 
2. Explicit Type Casting  
This is when we explicitly specify how to cast the data to another data type
``` py
myStringNumber = "25"
print(type(myStringNumber))
myIntNumber = int(myStringNumber)
print(type(myIntNumber))
myFloatNumber = float(myIntNumber)
print(type(myFloatNumber))
```
```
# Output
<class 'str'>
<class 'int'>
<class 'float'>
```

## Concatenation
Adding two or more things together.
``` py
a = "Hello"
b = "World"
c = a + " " + b
print(c) # Prints Hello World
```
We cannot Concatenate string with numeric formats
``` py
name = "Subodh"
marks = 50
name_and_marks = name + " " + marks # this line will result in error
name_and_marks = name + " " + string(marks) #This is fine
print(name_and_marks) # Prints Subodh 50
print(name, marks) # Also Prints Subodh 50.
# Note(s) 
# 1. here we don't need to perform type casting while sending values to print method, Python does it for us.
# 2. Python adds space before printing each parameter, we don't need to supply space as well.
```

## input
USe this method to  take input from user on console.
``` py
name = input("Please Enter your name ")
print ("Hi", name, "How old are you today?")
age = int(input())
age_next_year = age + 1
print(name, "you will be", age_next_year, "years old next year")
```
``` 
#Output
Please Enter your name Subodh
Hi Subodh How old are you today?
40
Subodh you will be 41 years old next year
```
## Operators

### Arithmetic Operators
We have following Arithmetic operators in Python.  
| Operator | Name | Syntax | Output |
| :---:    | :--- | :---   | :----  |
| + | Addition | print(10 + 2) | 12 |
| - | Subtraction| print(10 - 2)| 8 |
| * | Multiplication|  print(10 * 2)| 20 |
| / | Division|  print(10 / 2)| 5 |
| % | Modulus|  print(10 % 3)| 1 |
| / | Floor Division| print(4.4 // 2)| 2 |

### Exponential Operators
This is used to calculate base <sup>exponent</sup> operation.
``` python
print(2**3) #Prints 8
```

### Logical Operators
These are used to combine multiple statements together for some decision making.
| Operator | Name | Syntax | Output |
| :---:    | :--- | :---   | :----  |
| and | Logical AND | print(True and True) | True |
| or  | Logical OR| print(True or False)| True |
| not | Logical NOT|  print(not True)| False |


### Comparison Operators
These are used to compare values and return boolean output which can be then used for Logical operation checks.
| Operator | Name | Syntax | Output |
| :---:    | :--- | :---   | :----  |
| == | Equal To? | print(3 == 4) | False |
| !=  | Not Equal To? | print(3 != 4)| True |
| > | Greater Than? |  print( 3> 4)| False |
| < | Less Than? |  print(3 < 4)| True |
| >= | Greater Than or Equal To |  print(4 >= 4)| True |
| <= | Less Than of Equal To |  print(4 <= 4)| True |

### Operator Precedence 
This sets the precedence of the operators.  
Note Some operators are not listed above (will add later) 
| Operator | Description | Precedence | Associativity |
| --- | --- | -- | --|
| () | Brackets | 1 (highest) | Left-to-Right |
| Function calls, slicing, attribute access | |  2 | Left-to-Right |
| ** | Exponential Operator | 3 | **Right-to-Left** |
| +x, -x, ~x | Unary plus, minus, bitwise NOT | 4 | **Right-to-Left** |
| *, /, //, %| Multiplication, Division, Floor Div, Modulo | 5 | Left-to-Right |
| +, - | Addition Subtraction | 6 | Left-to-Right |
| <<, >> | Bitwise Shifts | 7 | Left-to-Right |
| & | Bitwise AND | 8 | Left-to-Right |
| ^ | Bitwise XOR | 9 | Left-to-Right |
| \| |  Bitwise OR | 10 | Left-to-Right |
| ==, !=, >, <, is, in | Comparisons, identity, membership | 11 | Left-to-Right |
| not | Logical NOT | 12 | **Right-to-Left** |
| and | Logical AND | 13 | Left-to-Right |
| or | Logical OR | 14 | Left-to-Right |
| := | Walrus operator (Assignment expression) | 15 (Lowest) | **Right-to-Left** |

## Indexing
When we have data represented in a collection, each element is assigned an index. for e.g. string is a collection of characters and each character is assigned an index.  
##### Notes
1. Positive index starts with 0.
2. Negative index starts with -1  

Lets look at some indexing functions.

### Using [] to read value at Index
``` py
name = "Subodh"
print(name[-3], name[-2], name[-1], name[0], name[1], name[2]) #Prints S u b S u b
```
So if a String contains value Subodh, we can picture it as 
| -6 | -5 | -4 | -3 | -2 | -1 | 0 | 1 | 2 | 3 | 4 | 5 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| S | u | b | o | d | h | S | u | b | o | d | h |

### index()
``` py
name = "SAMSUNG"
print(name.index('S')) #Prints 0 which is the first occurrence of S
```

### len()
``` py
name = "SAMSUNG"
print(len(name)) #Prints 7 which is the number of characters
```

### 
``` py
name = "SAMSUNG"
print(len(name) // 2) #Prints 7 which is the number of characters
```
### How to find Middle character?
We know that // is a floor division operator. Lets see how we can use that, len and [] operator to find middle character 
``` py
name = "SAMSUNG" #This is 7 character string 7//2 will give us 3.
print(name[len(name) // 2]) #Prints S which is the exact middle character

name = "SAMSUN" #This is 6 character string 6//2 will also give us 3
print(name[len(name) // 2]) #Prints S which is one of the middle characters as this is an even length string.
```

## Slicing 
Slicing is extraction a portion (slice) from a collection  
We use [ ] brackets to slice out a portion. Some basic Slicing examples for a string names SAMSUNG
| Example | Output | Description |
| --- | --- | --- |
|print(name[1:3]) | AM | Start from Index 1 and go till 3 minus 1. Basically |start is included in slice but end is not included
|print(name[:3]) <br> print(name[-7:]) | SAM <br> SAMSUNG | Start from Index 0 and go till 3 minus 1. <BR> Start from -7 and go till 0|
|print(name[1:]) | AMSUNG | Start from Index 1 and go till Length minus 1  |(basically till end)
|print(name[:]) | SAMSUNG | Prints entire string, starting as 0 and ending at Length minus 1. |
| print(name[0:7:2]) <br> print(name[0:7:3]) <br> print(name[0:7:4])| SMUG <br> SSG <br> SU | Start from index 0 and then print every 2nd element till(7-1) <br> Start from index 0 and then print every 3rd element till(7-1) <br> Start from index 0 and then print every 4th element till(7-1) |
| print(name[0:7:2]) <br> print(name[0:7:3]) <br> print(name[0:7:4])| SMUG <br> SSG <br> SU | Start from index 0 and then print every 2nd element till(7-1) <br> Start from index 0 and then print every 3rd element till(7-1) <br> Start from index 0 and then print every 4th element till(7-1) |
|print(name[:]) | SAMSUNG | Prints entire string, starting as 0 and ending at Length minus 1. |
|print(name[::-1]) <br> print(name[::-2])| GNUSMAS <br> GUMS| Start to end in reverse order <br> Start to end, print every 2nd character in reverse order |
| print(name[1:-1]) | AMSUN | Starts from index 1 and will go till (-1 -1) which is -2 which is equal to 2nd last element.

### Indexing Vs Slicing
1. Index checks position of a single item in collection
2. Slicing can take one or more or all elements of a collection
3. Slicing contains 3 elements inside [] 
    1. Start Index (included in slice)
	2. End (not included in Slice)
	3. step (take every n<sup>th</sup> value)
	
## Conditional Statements
``` py
temp = int(input("Enter temperature "))
if temp > 30:
    print("Too Hot")
elif temp >= 25 and temp <= 30:
    print("Bearable")
elif temp > 15:
    print("Pleasant")
else:
    print("Cold")
```
	
## Loops
Loops are used to perform repetitive action on same or changing data set 

### For Loop
``` py
for i in range(1,6): # starts from 1 and ends at 6-1, similar to slicing
	print(i)
```
``` py
# Output
1
2
3
4
5
```

#### While Loop
``` py
temp = 1
while temp != 6:
    print(temp)
    temp +=1
```
``` py
# Output
1
2
3
4
5
```
#### Note - We d DO NOT have do While loop in Python


## Functions
Functions are defined with def keyword followed by  
1. FunctionName
2. Parameters - comma separated inside round brackets

#### Notes
1. We do not define return type in the Function definition
2. Method will return value based on the first return statement 
3. It is mandatory to define the method before calling it as this is interpreter based language, rather than a compiled language. 

``` py
def Square(myInt) :
    return (myInt * myInt)
    return (myInt) # this is ignored

temp = 1
while temp != 4:
    print(Square(temp))
    temp +=1
```
``` py
# Output
1
4
9
```
	
## Collections
Collections are ways to store a group of data. e.g. String is a group of characters.
#### Note(s)
1. In Python, Collections are not fixed to contain a uni data type.

### List
List is an Ordered Collection has following properties
1. Ordered list of items (any data types).
2. This is mutable which means
    1. values can be changed at specific index
	2. appended at the end or 
	3. insert at a specific index (rest of the elements get shifted)
	4. We can pop value at specific position (will remove that element and shift rest of the elements)
	5. Pop at the end
3. Duplicate values are allowed
4. **Declared with square brackets []**  

Lets see these in action
``` py
my_list = [1, "two", 3.5, True, False ]
print(my_list) 
my_list[2] = "Three.Five"
print(my_list)
my_list.append("Six")
print(my_list) 
my_list.pop()
print(my_list) 
my_list.insert(2, "Three.Five") # If index is beyond length, it adds to the end, basically like append
print(my_list) 
my_list.pop(2)
print(my_list)
print(my_list.__len__()) # Here __len__ is a Dunder method

my_list2 = ["Tom", "Kick", "Hairy"]
my_list.extend(my_list2) ## Add my_list2 to my_list
print(my_list)
```
``` py
#Output
[1, 'two', 3.5, True, False]
[1, 'two', 'Three.Five', True, False]
[1, 'two', 'Three.Five', True, False, 'Six']
[1, 'two', 'Three.Five', True, False]
[1, 'two', 'Three.Five', 'Three.Five', True, False]
[1, 'two', 'Three.Five', True, False]
5
[1, 'two', 'Three.Five', True, False, 'Tom', 'Kick', 'Hairy']
```
	
### Tuple
Tuples is an Ordered Collection with following properties
1. Ordered list of items (any data types).
2. This is immutable which means
    1. Data cannot be changed.
	2. We cannot use insert, append, pop or indexer ([]) to change value.
3. We can only use methods like index, Count, Length, etc
4. Duplicate values are allowed
5. **Declared with round brackets ()**  

``` py
my_tuple = (1, "two", "two", 3.5, True, False )
print(my_tuple)
print(my_tuple[2]) #Print value at index 2
print(my_tuple.count("two")) #Print number of time we have "two" in the tuple
print(my_tuple.__len__()) #Print Length of tuple
print(type(my_tuple)) #Print type of tuple
```
``` py
#Output 
(1, 'two', 'two', 3.5, True, False)
two
2
6
<class 'tuple'>
```
String is as example of Tuple as they are immutable, once defined, we cannot edit the same object. Any changes like appending another string actually create a new String object in memory, old one remains same.

### Set
Set is an Un-Ordered Collection with following properties
1. Duplicates are not allowed
2. Un-Ordered - which means we cannot access elements by an index number.
3. Partially Mutable, we can perform following operations
    1. Add an element
	2. Remove an element (remove and throw error if element not found)
	3. Discard (remove but don't throw error if element not found)
	4. We can union two Sets resulting in values for both (no duplicates as we cannot have duplicates). Basically, we can perform Union operation, not Union All.
	5. We can perform intersection of two sets which will result in only common elements from the two sets (without duplicates off course)
	6. We can perform difference that will give list elements from first set which are missing in the second. Like Left Outer Join
	7. We can perform symmetric difference, which will give non common elements from both. This is like opposite of intersection? 
4. **Defined using Curly braces {}**  


### Dictionary
Dictionary is an Un-Ordered Collection with following properties
1. Its a collection of Key-Value pairs
2. Keys must be unique
3. Un-Ordered - which means we cannot access elements by an index number.
4. Partially Mutable, we can perform following operations
	1. Add
	2. Remove
	3. Update value for a specific Key
3. Defined with Curly braces {}

Unordered collection
	Set - Un-ordered list, partially mutable (we cannot use indexes, so index specific element cannot be removed / added).
		We can use add to store at the end. Cannot have duplicate values
	
		my_set = {1, 'two', 3.5, true, "five"} #declared using curly brackets
		my_set2 = {11, 'two two', 3.5, true} #declared using curly brackets
		my_set.add("new elemen") #allowed (adds anywhere not always at the end as it is un ordered)
		my_set.remove('two') #finds and removes value (throws error when element not found)
		my_set.discard (1)  #finds and remove (no error no operation if element not found)
		my_set.union(my_set2) # will give union (common elemens will be returned only once)
		my_set.intersection(my_set2) # will give common values only
		my_set.difference(my_set2) # prints elements from my_set which are not present in my_set2
		my_set.symmetric_difference(my_set2) # prints elements from my_set and my_set2 which are not present in both (basically opposite od intersection
	
	Dictionary -- Un-ordered key value pair, immutable (we cannot use indexes though, we can use key to change value or remove).
		We can add new items as well. Duplicate keys not allowed
		
		my_dict = {"Name" : "Subodh", "Age" : 22} #declared with curly brackets 
		my_dict.keys() #prints all keys
		my_dict.values() #prints all values
		my_dict.items() #prints all key-values
		my_dict.update({"Name" : "Amita"})
		
		how to read specific?
		
Session 4 -- March 1 -- Practice Session

``` py
def PrintTable(number):
  print ("Priniting Table of ", number)
  for i in range(1, 11):
    j = i * number
    print(f"{number} X {i} = {i * number}")

number = int(input("Enter your number "))
PrintTable(number)
```
``` py
my_list = []
for i in range(1, 51):
  my_list.append(i)

sum = 0
evenCount = 0
for i in range(0, len(my_list)):
  sum = sum + my_list[i]
  if my_list[i] % 2 == 0 : 
    evenCount = evenCount + 1
print(f"Sum of all elements is {sum}")
print(f"Total number of even numbers is {evenCount}")
print(f"Reverse {my_list[::-1]}")
print(f"{my_list}")
```

``` py
my_vowel_set = {'a', 'e', 'i','o', 'u'}
my_string = input("Enter your string : ")
my_vowel_count = 0
for i in range(0, len(my_string)):
  if my_string[i].lower() in my_vowel_set:
    my_vowel_count = my_vowel_count + 1
print(f"Number of Vowels in input string = {my_vowel_count}")
```

``` py
def IsNumberPrime(number):
  for i in range(2, number):
    if number % i == 0:
      return False
  return True

my_list_prime = []
my_list_composite = []
for number in range(2, 101):
  if IsNumberPrime(number) == True:
    my_list_prime.append(number)
  else:
    my_list_composite.append(number)
print(f"Prime Number : {my_list_prime}")
print(f"Composite Numbers : {my_list_composite}")
```

#### max will only work when all elements in the array are numeric
``` py
my_list = [1, 5, 2, 25, 100, 75, 87.5]
print(f"Range Loop Biggest number in the List is {max(my_list)}")

biggestNumber = 0
for i in range(0, len(my_list)):
  if isinstance(my_list[i], int):
    if my_list[i] > biggestNumber:
      biggestNumber = my_list[i]
print(f"Range Loop Biggest number in the List is {biggestNumber}")

biggestNumber = 0
for element in my_list:
  if isinstance(element, int):
    if element > biggestNumber:
      biggestNumber = element
print(f"Element Loop Biggest number in the List is {biggestNumber}")
```
``` py
number = int(input("Enter number : "))
sum_of_all_digits = 0
number_clone = number
while number_clone > 0:
  sum_of_all_digits = sum_of_all_digits + number_clone % 10
  number_clone = number_clone // 10
print(f"Sum of all digits of {number} is {sum_of_all_digits}")
```

``` py
my_list = [1, 2, 3, 4, 5, 6, 1, 1, 1, 2, 3, 4, 4]
element_count = 0
number = int(input("Enter number : "))
for element in my_list:
  if element == number:
    element_count = element_count + 1
print(f"{number} found {element_count} times in list {my_list}")
print(f"{number} found {my_list.count(number)} times in list {my_list}")
```

``` py
my_list = [1, 2, 3, 4, 5, 6, 1, 1, 1, 2, 3, 4, 4]
number = int(input("Enter number : "))
for i in my_list[:]:
  print(i)
  if (i == number):
    my_list.remove(number)
print(f"{my_list}")
```

``` py
number = int(input("Enter number : "))

#Method 1 -- recursive function
def GetFactorial(number):
  if number == 1:
    return 1
  else:
    return number * GetFactorial(number - 1)
print(f"Factorial of {number} using recursive function is {GetFactorial(number)}")

#Method 2 -- normal loop
factorial = 1
while number > 1:
  factorial = factorial * number
  number = number -1
print(f"Factorial of {number} is {factorial}")
```

``` py
number = int(input("Enter number : "))

#Method 1 -- recursive function
def GetFactorial(number):
  if number == 1:
    return 1
  else:
    return number * GetFactorial(number - 1)
print(f"Factorial of {number} using recursive function is {GetFactorial(number)}")

#Method 2 -- normal loop
factorial = 1
for i in range(1, number + 1):
  factorial = factorial * i
print(f"Factorial of {number} using for loop is {factorial}")

#Method 3 -- normal loop
factorial = 1
while number > 1:
  factorial = factorial * number
  number = number -1
print(f"Factorial of {number} using while loop is {factorial}")
```

```
my_list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 5, 6, 7, 8]
my_set = set()

isFound = False
for element in my_list:
  if element in my_set:
    isFound = True
    print(f"{element} is the first repeating element in {my_list}")
    break;
  else:
    my_set.add(element)
if isFound == False:
  print(f"No repeating elements in {my_list}")
```  

Assignment
1. check prime palindrome number
2. check for armstrong number
3. perfect (complete number)
4. fibonacci 
5. palindrome string