import json

# Load the JSON data
with open('Users_data_April12.json', 'r') as file:
    data = json.load(file)

# Initialize counters
zero_count_chase = 0
greater_than_zero_count_chase = 0
zero_count_reasons_chase = {}
greater_than_zero_count_reasons_chase = {}

# Iterate through the chase data
for chase_id, chase_info in data['ChaseData'].items():
    level_name = chase_info['levelName']
    number_of_change = chase_info['NumberOfChange']
    stopped_reason = chase_info['Stopped']

    # Check if the number of changes is 0 or greater than 0
    if number_of_change == 0:
        zero_count_chase += 1
        if level_name not in zero_count_reasons_chase:
            zero_count_reasons_chase[level_name] = {}
        if stopped_reason in zero_count_reasons_chase[level_name]:
            zero_count_reasons_chase[level_name][stopped_reason] += 1
        else:
            zero_count_reasons_chase[level_name][stopped_reason] = 1
    else:
        greater_than_zero_count_chase += 1
        if level_name not in greater_than_zero_count_reasons_chase:
            greater_than_zero_count_reasons_chase[level_name] = {}
        if stopped_reason in greater_than_zero_count_reasons_chase[level_name]:
            greater_than_zero_count_reasons_chase[level_name][stopped_reason] += 1
        else:
            greater_than_zero_count_reasons_chase[level_name][stopped_reason] = 1

print(zero_count_reasons_chase)
print(greater_than_zero_count_reasons_chase)

# Print the statistics for ChaseData
print("Statistics for ChaseData:")
print(f"Count of ChaseData with zero occurrences: {zero_count_chase}")
print(f"Count of ChaseData with occurrences greater than zero: {greater_than_zero_count_chase}")

print("\nReasons for ChaseData with zero occurrences:")
for level, reasons in zero_count_reasons_chase.items():
    print(f"Level: {level}")
    for reason, count in reasons.items():
        print(f"- Reason: {reason}, Count: {count}")

print("\nReasons for ChaseData with occurrences greater than zero:")
for level, reasons in greater_than_zero_count_reasons_chase.items():
    print(f"Level: {level}")
    for reason, count in reasons.items():
        print(f"- Reason: {reason}, Count: {count}")
