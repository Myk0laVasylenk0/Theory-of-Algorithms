
def print_dict_as_pretty_table(d):
    # Headers for the table
    headers = ['Hash', 'First Name', 'Last Name', 'Date of Birth']

    # Calculate the maximum width for each column
    column_widths = [len(header) for header in headers]
    for id, data in d.items():
        column_widths[0] = max(column_widths[0], len(str(id)))
        if isinstance(data, tuple):
            for i, field in enumerate(data, start=1):
                column_widths[i] = max(column_widths[i], len(str(field)))
        elif data == "Empty" or data is None:
            # Assuming "Empty" or None should occupy the same space
            placeholder_text = "Empty" if data == "Empty" else "N/A"
            for i in range(1, len(headers)):
                column_widths[i] = max(column_widths[i], len(placeholder_text))

    # Helper function to print a row
    def print_row(items, widths):
        row_format = "| " + " | ".join(["{:<" + str(width) + "}" for width in widths]) + " |"
        print(row_format.format(*items))

    # Print table border
    def print_border(widths):
        border_pieces = ["-" * (width + 2) for width in widths]
        border = "+" + "+".join(border_pieces) + "+"
        print(border)

    # Print the header
    print_border(column_widths)
    print_row(headers, column_widths)
    print_border(column_widths)

    # Print the data rows
    for id, data in d.items():
        row = [id]
        if isinstance(data, tuple):
            row.extend(data)
        elif data == "Empty":
            # Fill in 'Empty' for all data columns
            row.extend(['Empty'] * (len(headers) - 1))
        elif data is None:
            # Fill in 'N/A' for None data
            row.extend(['N/A'] * (len(headers) - 1))
        print_row(row, column_widths)
        print_border(column_widths)


def print_dict_as_pretty_table_hided(d):
    # Headers for the simplified table
    headers = ['Hash', 'Date of Birth']

    # Calculate the maximum width for each column, focusing on ID and Date of Birth
    column_widths = [len(header) for header in headers]
    for id, data in d.items():
        column_widths[0] = max(column_widths[0], len(str(id)))
        if isinstance(data, tuple):
            # Date of Birth is the third element in the tuple
            column_widths[1] = max(column_widths[1], len(str(data[2])))
        elif data == "Empty" or data is None:
            # Assuming "Empty" or None should occupy the same space
            placeholder_text = "Empty" if data == "Empty" else "N/A"
            column_widths[1] = max(column_widths[1], len(placeholder_text))

    # Helper function to print a row
    def print_row(items, widths):
        row_format = "| " + " | ".join(["{:<" + str(width) + "}" for width in widths]) + " |"
        print(row_format.format(*items))

    # Print table border
    def print_border(widths):
        border_pieces = ["-" * (width + 2) for width in widths]
        border = "+" + "+".join(border_pieces) + "+"
        print(border)

    # Print the header
    print_border(column_widths)
    print_row(headers, column_widths)
    print_border(column_widths)

    # Print the data rows
    for id, data in d.items():
        dob = 'N/A'  # Default for None or when the Date of Birth is not applicable
        if isinstance(data, tuple):
            dob = data[2]  # Extracting Date of Birth from the tuple
        elif data == "Empty":
            dob = 'Empty'
        print_row([id, dob], column_widths)
        print_border(column_widths)


my_dict = {
    0: ('Andjelika', 'Vosnyak', '2006-05-20'),
    1: ('Valeria', 'Korol', '2005-06-15'),
    2: ('Anastasia', 'Malinska', '2006-09-10'),
    3: ('Anastasia', 'Prokopchuk', '2006-05-28'),
    4: None,
    5: 'Empty',
    6: None,
    7: None,
    8: ('Maria', 'Sarabun', '2005-12-04'),
    9: None,
    10: None,
    11: ('Maria', 'Sarabun', '2005-12-04'),
    12: ('Daryna', 'Dzubenko', '2006-06-23'),
    13: None,
    14: None,
    15: None,
    16: None,
    17: ('Sofia', 'Katasonova', '2006-06-11'),
    18: ('Daryna', 'Rudiuk', '2006-07-02'),
    19: ('Sofia', 'Lubarska', '2005-11-25')
}
# print_dict_as_pretty_table_hided(my_dict)
