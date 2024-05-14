from FixedDict import FixedLengthDict
import math
from datetime import date, datetime
from cool_dict import print_dict_as_pretty_table as display_hash_table
from cool_dict import print_dict_as_pretty_table_hided as display_hash_table_hided
import time
from time import perf_counter_ns


def convert_string_to_unicode(string):
    splitted_string = [char for char in string]
    char_sum_unicode = 0
    for char in splitted_string:
        char_sum_unicode += ord(char)
    return char_sum_unicode


def string_multiplication_hash_function(key_string, hash_table_size, int_constant_value=0.357840):
    return math.floor(hash_table_size * (convert_string_to_unicode(key_string) * int_constant_value % 1))


def fill_dict_with_null_values(dictionary):
    for i in range(dictionary.max_length):
        dictionary[i] = None
    return dictionary


def liniar_zonding(key_string, i, hash_table_size):
    return (string_multiplication_hash_function(key_string, hash_table_size) + i) % hash_table_size


def double_hashing_zonding(key_string, i, hash_table_size):
    def additional_hash_function():
        return 1 + (convert_string_to_unicode(key_string) % (hash_table_size - 3))

    return ((string_multiplication_hash_function(key_string, hash_table_size) + i * additional_hash_function())
            % hash_table_size)


def add_element_to_hash_table(hash_table, data_tuple, zonding_method):
    key_string = data_tuple[0] + data_tuple[1]

    if zonding_method == "liniar":
        zonding_function = liniar_zonding
    elif zonding_method == "double hashing":
        zonding_function = double_hashing_zonding
    else:
        print("Invalid zonding method")
        return None

    hashed_key = string_multiplication_hash_function(key_string, hash_table.max_length)

    i = 0
    is_elemnet_added = False

    while i < hash_table.max_length:
        if hash_table.__getitem__(hashed_key) in [None, "Empty"]:
            hash_table.__setitem__(hashed_key, data_tuple)
            is_elemnet_added = True
            break
        else:
            i += 1
            hashed_key = zonding_function(key_string, i, hash_table.max_length)

    if is_elemnet_added == True:
        print("element successfully added")
    else:
        print("unable to add element")


def find_element_in_hash_table(hash_table, data_tuple, zonding_method):
    key_string = data_tuple[0] + data_tuple[1]

    if zonding_method == "liniar":
        zonding_function = liniar_zonding
    elif zonding_method == "double hashing":
        zonding_function = double_hashing_zonding
    else:
        print("Invalid zonding method")
        return None

    hashed_key = string_multiplication_hash_function(key_string, hash_table.max_length)

    i = 0
    is_element_found = False

    while i < hash_table.max_length:
        value = hash_table.__getitem__(hashed_key)
        if value == None:
            i += 1
            hashed_key = zonding_function(key_string, i, hash_table.max_length)
            is_element_found = False
            continue
        elif zonding_method == "liniar" and value == None:
            is_element_found = False
            break
        elif value[0] + value[1] == key_string:
            is_element_found = True
            break
        else:
            i += 1
            hashed_key = zonding_function(key_string, i, hash_table.max_length)
            is_element_found = False

    if is_element_found == True:
        print("Element found")
        # print(f"key: {hashed_key} value: {hash_table.__getitem__(hashed_key)}")
        print(f"girl's birthday: {value[2]}")
    else:
        print("Elemnt not found")


def remove_element_from_hash_table(hash_table, data_tuple, zonding_method):
    key_string = data_tuple[0] + data_tuple[1]

    if zonding_method == "liniar":
        zonding_function = liniar_zonding
    elif zonding_method == "double hashing":
        zonding_function = double_hashing_zonding
    else:
        print("Invalid zonding method")
        return None

    hashed_key = string_multiplication_hash_function(key_string, hash_table.max_length)

    i = 0
    is_element_deleted = False

    while i < hash_table.max_length:
        value = hash_table.__getitem__(hashed_key)

        if value == None:
            i += 1
            hashed_key = zonding_function(key_string, i, hash_table.max_length)
            is_element_deleted = False
            continue

        elif value[0] + value[1] == key_string:
            hash_table.__delitem__(hashed_key)
            hash_table.__setitem__(hashed_key, "Empty")
            is_element_deleted = True
            break
        elif zonding_method == "liniar" and value == None:
            is_element_deleted = False
            break
        else:
            i += 1
            hashed_key = zonding_function(key_string, i, hash_table.max_length)
            is_element_deleted = False

    if is_element_deleted == True:
        print(f"{data_tuple[0]} {data_tuple[1]} has been deleted")
    else:
        print("Unable to delete element")


# testing our program

hash_table_size = 20
hash_table_girls = FixedLengthDict(hash_table_size)

fill_dict_with_null_values(hash_table_girls)

girls_data_list = [

    ("Maria", "Sarabun", date(2020, 1, 1).isoformat()),
    ("Sophia", "Johnson", date(2019, 5, 12).isoformat()),
    ("Isabella", "Williams", date(2018, 9, 23).isoformat()),
    ("Olivia", "Jones", date(2017, 11, 4).isoformat()),
    ("Emma", "Brown", date(2016, 2, 15).isoformat()),
    ("Ava", "Davis", date(2015, 7, 28).isoformat()),
    ("Charlotte", "Miller", date(2014, 3, 9).isoformat()),
    ("Amelia", "Wilson", date(2013, 8, 20).isoformat()),
    ("Mia", "Moore", date(2012, 12, 31).isoformat()),
    ("Emily", "Taylor", date(2020, 7, 7).isoformat()),
    ("Nora", "Allen", date(2020, 9, 15).isoformat()),
    ("Eleanor", "Parker", date(2019, 2, 26).isoformat()),
    ("Hazel", "Hill", date(2018, 6, 7).isoformat()),
    ("Zoe", "Roberts", date(2017, 10, 18).isoformat()),
    ("Paisley", "Wright", date(2016, 4, 29).isoformat()),
    ("Aurora", "Price", date(2016, 1, 8).isoformat()),
    ("Lydia", "Butler", date(2015, 5, 19).isoformat()),
    ("Bella", "Fisher", date(2014, 10, 30).isoformat()),
    ("Mila", "Ward", date(2013, 12, 11).isoformat()),
    ("Ellie", "Barnes", date(2012, 6, 22).isoformat())
]


for girl in girls_data_list:
    add_element_to_hash_table(hash_table_girls, girl, "liniar")

start = perf_counter_ns()

find_element_in_hash_table(hash_table_girls, ("noname", "nosurename"), 'liniar')
stop = perf_counter_ns()

print("Elapsed time:", stop, 'ns', start, 'ns')

print("Elapsed time during the whole program",
      stop - start, 'ns')




























#
# print("Empty hash table created with size: {}".format(hash_table_size))
#
# exit_program = False
#
# while exit_program == False:
#
#     print("-----------------------")
#     print("Choose one option from list below:")
#     print("1. Add girl with her birthday to hash table")
#     print("2. Find girl's birtday")
#     print("3. Delete girl from hash table")
#     print("4. Display hash table")
#     user_option = int(input("Your option: "))
#
#     if user_option == 1:
#         print("Pleaese, enter the girl's name and surname.")
#         name = str(input("Name: "))
#         surname = str(input("Surname: "))
#         print("Please, enter girl's birthday (year-month-day). Example: 2005-07-01")
#         birthday = str(input("Birthday: "))
#         birhday_split = birthday.split("-")
#         year = int(birhday_split[0])
#         month = int(birhday_split[1])
#         day = int(birhday_split[2])
#         print("Please, choose zonding method (enter 1 or 2)")
#         print("(note, if you choose invalid option, default double hashing method will be used)")
#         print("1. liniar zonding")
#         print("2. double hashing zonding")
#         zonding_method = ""
#         user_method = int(input("Your option: "))
#         if user_method == 1:
#             zonding_method = "liniar"
#         elif user_method == 2:
#             zonding_method = "double hashing"
#         else:
#             print("Invalid option")
#             print("the default zonding method will be used")
#             zonding_method = "double hashing"
#
#         add_element_to_hash_table(hash_table_girls, (name, surname, date(year, month, day).isoformat()),
#                                   zonding_method)
#
#     elif user_option == 2:
#         print("Pleaese, enter the girl's name and surname.")
#         name = str(input("Name: "))
#         surname = str(input("Surname: "))
#         print("Please, choose zonding method (enter 1 or 2)")
#         print("(note, if you choose invalid option, default double hashing method will be used)")
#         print("1. liniar zonding")
#         print("2. double hashing zonding")
#         zonding_method = ""
#         user_method = int(input("Your option: "))
#         if user_method == 1:
#             zonding_method = "liniar"
#         elif user_method == 2:
#             zonding_method = "double hashing"
#         else:
#             print("Invalid option")
#             print("the default zonding method will be used")
#             zonding_method = "double hashing"
#
#         find_element_in_hash_table(hash_table_girls, (name, surname), zonding_method)
#
#     elif user_option == 3:
#         print("Pleaese, enter the girl's name and surname.")
#         name = str(input("Name: "))
#         surname = str(input("Surname: "))
#         print("Please, choose zonding method (enter 1 or 2)")
#         print("(note, if you choose invalid option, default double hashing method will be used)")
#         print("1. liniar zonding")
#         print("2. double hashing zonding")
#         zonding_method = ""
#         user_method = int(input("Your option: "))
#         if user_method == 1:
#             zonding_method = "liniar"
#         elif user_method == 2:
#             zonding_method = "double hashing"
#         else:
#             print("Invalid option")
#             print("the default zonding method will be used")
#             zonding_method = "double hashing"
#
#         remove_element_from_hash_table(hash_table_girls, (name, surname), zonding_method)
#
#     elif user_option == 4:
#         display_hash_table_hided(hash_table_girls)
#     else:
#         print("Invalid option")
#
#     print('')
#     print("Proceed working with hash table:")
#     print("Press [y] to proceed or any other key to close the program")
#
#     user_choice = str(input("Enter: "))
#     if user_choice == "y":
#         exit_program = False
#     else:
#         exit_program = True
#     print('')


