#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the circularArrayRotation function below.

a = [1, 2, 3]
k = 2
queries = [0, 1, 2]
kk = []

ab = a[-k:] + a[:-k]


i = 0
while i < len(a):
    kk.append(ab[queries[i]])
    i += 1

print(kk)
