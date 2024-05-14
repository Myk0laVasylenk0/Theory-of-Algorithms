
import datetime
from graphviz import Digraph
import time


class TreeNode:
    def __init__(self, key):
        self.left = None
        self.right = None
        self.val = key

class BinarySearchTree:
    def __init__(self):
        self.root = None

    def insert(self, key):
        if self.root is None:
            self.root = TreeNode(key)
        else:
            self._insert_recursive(self.root, key)

    def _insert_recursive(self, node, key):
        if key < node.val:
            if node.left is None:
                node.left = TreeNode(key)
            else:
                self._insert_recursive(node.left, key)
        else:
            if node.right is None:
                node.right = TreeNode(key)
            else:
                self._insert_recursive(node.right, key)

    def delete(self, key):
        self.root = self._delete_recursive(self.root, key)

    def _delete_recursive(self, node, key):
        if node is None:
            return node
        if key < node.val:
            node.left = self._delete_recursive(node.left, key)
        elif key > node.val:
            node.right = self._delete_recursive(node.right, key)
        else:
            if node.left is None:
                return node.right
            elif node.right is None:
                return node.left
            else:
                min_larger_node = self._find_min(node.right)
                node.val = min_larger_node.val
                node.right = self._delete_recursive(node.right, min_larger_node.val)
        return node

    def _find_min(self, node):
        while node.left is not None:
            node = node.left
        return node

    def search(self, key):
        path = []
        result = self._search_recursive(self.root, key, path)
        if result:
            print(f"Lepricon found cave with {key} gold ingots!")
            print("Path to cave: " + " => ".join(map(str, path)))
        else:
            # print(f"No cave with {key} gold ingots")
            # print(f"Digging new cave with {key} gold ingots")
            return False


    def _search_recursive(self, node, key, path):
        if node is None:
            return False
        path.append(node.val)  # Track the current node value
        if node.val == key:
            return True
        elif key < node.val:
            return self._search_recursive(node.left, key, path)
        else:
            return self._search_recursive(node.right, key, path)

    def display(self, filename='bst'):
        def add_nodes_edges(node, graph):
            if node:
                graph.node(str(node.val))
                if node.left:
                    graph.edge(str(node.val), str(node.left.val))
                    add_nodes_edges(node.left, graph)
                if node.right:
                    graph.edge(str(node.val), str(node.right.val))
                    add_nodes_edges(node.right, graph)

        graph = Digraph()
        add_nodes_edges(self.root, graph)
        graph.render(filename, format='png', cleanup=True)
        # print(f"Graph saved as {filename}.png")


# creating a base tree
bst = BinarySearchTree()
nodes = [20, 18, 15, 24, 12, 17, 16, 19, 7, 5, 25, 23, 21, 28, 27, 30, 35, 29, 3, 1]

for node in nodes:
    bst.insert(node)


bst.display()



# print("--------------------------------------------")
# print("")
#
# # searching a specific node
# test_nodes_lst = [1, 16, 21, 27, 35]
# for node in test_nodes_lst:
#     start_time = time.perf_counter()
#     bst.search(node)
#     end_time = time.perf_counter()
#     elapsed_time = (end_time - start_time)
#     print(f"found node: {node} execution time: {elapsed_time} s of CPU time")
#     print("")
# print("--------------------------------------------")
# print("")
#
#
# # adding a specific node
# test_nodes_lst = [2, 4, 22, 31, 36]
# for node in test_nodes_lst:
#     start_time = time.perf_counter()
#     bst.insert(node)
#     end_time = time.perf_counter()
#     elapsed_time = round((end_time - start_time) * 10 ** 3, 4)
#     print(f"inserted node: {node} execution time: {elapsed_time} ms of CPU time")
#     print("")
# print("--------------------------------------------")
# print("")
#
# # deleting a specific node
# test_nodes_lst = [3, 16, 21, 28, 31]
# for node in test_nodes_lst:
#     start_time = time.perf_counter()
#     bst.delete(node)
#     end_time = time.perf_counter()
#     elapsed_time = round((end_time - start_time) * 10 ** 3, 4)
#     print(f"deleted node: {node} execution time: {elapsed_time} ms of CPU time")
#     print("")
# print("--------------------------------------------")
# print("")



# nodes_sorted = sorted(nodes)
# print(nodes_sorted[9])
# print(nodes_sorted[10])
# print(len(nodes_sorted))
# print(nodes_sorted[int(len(nodes_sorted) / 2) ])

# bst.display()

# from statistics import mean
# print(mean(nodes))

# # bst.insert(1000)
# # bst.delete(18)
# bst.display()

class LepriconGold:
    def __init__(self):
        pass

    def search_cave_with_gold(self, gold_ingots_count):
        if bst.search(gold_ingots_count) != False:
            pass
        else:
            print("No cave with entered gold ingots count")
            print(f"Digging a new cave with {gold_ingots_count} gold ingots")
            bst.insert(gold_ingots_count)
            bst.search(gold_ingots_count)


# interaction with user via console
LepriconGold = LepriconGold()

confirmation = "y"
while confirmation == "y":
    print("--------------------")
    gold_ingots_count = int(input("Searched number of gold ingots: "))
    LepriconGold.search_cave_with_gold(gold_ingots_count)
    confirmation = input("press [y] to continue (any other key to exit) ")


































# print("--------------------------------------------")
# print("")
#
# # searching a specific node
# test_nodes_lst = [1, 16, 21, 27, 35]
# for node in test_nodes_lst:
#     start_time = time.perf_counter()
#     bst.search(node)
#     end_time = time.perf_counter()
#     elapsed_time = (end_time - start_time)
#     print(f"found node: {node} execution time: {elapsed_time} s of CPU time")
#     print("")
# print("--------------------------------------------")
# print("")
#
#
# # adding a specific node
# test_nodes_lst = [2, 4, 22, 31, 36]
# for node in test_nodes_lst:
#     start_time = time.perf_counter()
#     bst.insert(node)
#     end_time = time.perf_counter()
#     elapsed_time = round((end_time - start_time) * 10 ** 3, 4)
#     print(f"inserted node: {node} execution time: {elapsed_time} ms of CPU time")
#     print("")
# print("--------------------------------------------")
# print("")
#
# # deleting a specific node
# test_nodes_lst = [3, 16, 21, 28, 31]
# for node in test_nodes_lst:
#     start_time = time.perf_counter()
#     bst.delete(node)
#     end_time = time.perf_counter()
#     elapsed_time = round((end_time - start_time) * 10 ** 3, 4)
#     print(f"deleted node: {node} execution time: {elapsed_time} ms of CPU time")
#     print("")
# print("--------------------------------------------")
# print("")


























# adding a specific node
# node = 35
# start_time = time.perf_counter()
# bst.search(node)
# end_time = time.perf_counter()
# elapsed_time = round((end_time - start_time) * 10**6, 4)
# print(f"found node: {node} execution time: {elapsed_time} µs of CPU time")
# print("")
#
# node = 1
# start_time = time.perf_counter()
# bst.search(node)
# end_time = time.perf_counter()
# elapsed_time = round((end_time - start_time) * 10**6, 4)
# print(f"found node: {node} execution time: {elapsed_time} µs of CPU time")
# print("")
#
# node = 16
# start_time = time.perf_counter()
# bst.search(node)
# end_time = time.perf_counter()
# elapsed_time = round((end_time - start_time) * 10**6, 4)
# print(f"found node: {node} execution time: {elapsed_time} µs of CPU time")
# print("")









































