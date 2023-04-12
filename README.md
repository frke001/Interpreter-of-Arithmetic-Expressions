# Interpreter of Arithmetic Expressions

This program is an arithmetic expression interpreter that supports proper execution of operations on integers. The supported functionalities are:

- addition, subtraction, multiplication, and integer division,
- printing the value of expressions and variable values using the print command, which takes an expression or variable name as input,
- properly interpreting negative numbers in expressions,
- grouping arithmetic expressions using parentheses, and
- assigning values to variables and using variables within expressions.

The program enables the construction of a parsing tree (which can be viewed in debugging mode) and is properly covered by unit tests. The implementation uses only the standard library, and the use of lexical analyzer generators and parser generators is not allowed.

## Example 

Input:<br>
5 + 4;<br>
a = 25 * 3 + 7 + 2 * -1 + 5; b =<br>
52 – 25 – 1<br>
 ; 25;<br>
print(a);<br>
c = (((a)) ) + (-3 + b * (b + <br>
a)) / 2;<br>
print(b); print(c);<br>

Output:<br>
85<br>
26<br>
1526<br>

