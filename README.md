# Gilded Rose Refactoring Kata

This Kata is intended to showcase and develop proficiency with refactoring object oriented code.  It has a long and storied [history](http://twitter.com/TerryHughes) on the web and there's a good chance you can find [other variants](https://github.com/NotMyself/GildedRose) or even other solutions in whole or in part if you look hard enough.  That would defeat both the spirit and the point of the kata.  

## How to use this Kata

The simplest way is to just clone the code and start hacking away improving the design. You'll need to look at the ["Gilded Rose Requirements"](https://github.com/foxguardsolutions/GildedRose-Refactoring-Kata/blob/master/GildedRoseRequirements.txt) which explains what the code is for and what you have to do with it. You'll also need some tests to make sure you don't break the code while you refactor.

You could write some unit tests yourself, using the requirements to identify suitable test cases. To get you started, each language has a failing unit test in a popular test framework as a starting point for most languages.  You don't have to use that framework, but it's there as a starting point.

You may also want to make use of the "Text-Based" tests provided in this repository. (Read more about that in the next section)

Whichever testing approach you choose, the idea of the exercise is to showcase and improve your skills at designing test cases and refactoring. The idea is *not* to re-write the code from scratch, but rather to design tests, take small steps, run the tests often, and incrementally improve the design. 

## Text-Based Approval Testing

This is a testing approach which is very useful when refactoring legacy code. Before you change the code, you run it, and gather the output of the code as a plain text file. You review the text, and if it correctly describes the behaviour as you understand it, you can "approve" it, and save it as a "Golden Master". Then after you change the code, you run it again, and compare the new output against the Golden Master. Any differences, and the test fails.

It's basically the same idea as "assertEquals(expected, actual)" in a unit test, except the text you are comparing is typically much longer, and the "expected" value is saved from actual output, rather than being defined in advance.

Typically a piece of legacy code may not produce suitable textual output from the start, so you may need to modify it before you can write your first text-based approval test. That could involve inserting log statements into the code, or just writing a "main" method that executes the code and prints out what the result is afterwards. It's this latter approach we are using here to test GildedRose.

The Text-Based tests in this repository are designed to be used with the tool "TextTest" (http://texttest.org). This tool helps you to organize and run text-based tests. There is more information in the README file in the "texttests" subdirectory.

**Note that the text based approval tests do not cover all of the changes requested in ["Gilded Rose Requirements"](https://github.com/foxguardsolutions/GildedRose-Refactoring-Kata/blob/master/GildedRoseRequirements.txt).**