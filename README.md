# **Train Station Network Analyzer**

This project presents a C# code that explores various graph search algorithms, 
such as Depth-First Search (DFS), Iterative Deepening Depth-First Search (IDDFS), Hill Climbing, Greedy Search, and A* Search. The algorithms are 
used to find paths and analyze the performance of searching within a network of train stations and the time it takes to travel between them. 
The code leverages the geographical coordinates of the train stations and their connections to optimize routing and estimate various aspects of 
the search process. It's a valuable tool for studying different search algorithms and their efficiency in solving real-world route-finding problems.

<p align='center'>
<img src="https://github.com/danipaco0/Trains-Algorithms/assets/7733838/179f2acf-8579-4f2d-ad97-4946373134d6" width=600>
</p>

## **Depth-First Search (DFS):**

DFS is a classic graph traversal algorithm. It starts at the root node and explores as far as possible along each branch before 
backtracking. In this implementation, DFS uses a stack to maintain a LIFO order of visiting nodes.

<p align='center'>
<img src="https://github.com/danipaco0/Trains-Algorithms/assets/7733838/f36e4d02-b51d-4761-8eaa-85c82f9533b7" width=600>
</p>

## **Iterative Deepening Depth-First Search (IDDFS):**

IDDFS is an enhanced version of DFS. It repeatedly performs DFS with increasing depth limits, gradually exploring the graph in a layered manner.

<p align='center'>
<img src="https://github.com/danipaco0/Trains-Algorithms/assets/7733838/b5b836a0-57b2-40b8-ad14-f42efaba573c" width=600>
</p>

## **Hill Climbing:**

Hill Climbing is a local search algorithm. It evaluates neighboring states based on a heuristic function and moves to the best neighboring state. 
The process is repeated until a peak (best solution) is reached or no better neighbors exist. The heuristic function calculates the estimated 
straight-line (as-the-crow-flies) distance between the current state and the goal state using geographic coordinates. It provides an estimate of 
the minimum possible cost (travel time) to reach the goal directly from the current state.

<p align='center'>
<img src="https://github.com/danipaco0/Trains-Algorithms/assets/7733838/fe216077-3c23-41ab-8f59-336f1fafe980" width=600>
</p>

## **Greedy Search:**

Greedy Search is another informed search algorithm. It selects the best next step based on a heuristic, with no regard for previous steps. 
The algorithm continuously moves to the neighboring state with the lowest estimated cost. The heuristic function calculates the estimated 
straight-line distance between the current state and the goal state using geographic coordinates (the neighbor that appears to be closest to the goal).

<p align='center'>
<img src="https://github.com/danipaco0/Trains-Algorithms/assets/7733838/e6fd176b-43ba-402a-8baf-807c56463c84" width=600>
</p>

## **A Search:***

A* Search is an informed search algorithm that uses both the cost to reach a node and a heuristic to estimate the cost from that node to the goal. 
It prioritizes nodes with the lowest total cost (the sum of actual cost and heuristic). The key components of the heuristic are geographic coordinates and
travel time estimation.

<p align='center'>
<img src="https://github.com/danipaco0/Trains-Algorithms/assets/7733838/2bc3a795-653f-4061-924a-2c9d71e0fa0c" width=600>
</p>
