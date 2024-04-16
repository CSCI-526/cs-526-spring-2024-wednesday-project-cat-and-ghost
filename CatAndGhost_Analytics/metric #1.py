import json
from datetime import datetime

# Define a function to check if a date is valid and after a certain date
def is_valid_date_and_after(date_str, comparison_date):
    try:
        death_date = datetime.strptime(date_str, "%Y-%m-%d %H:%M:%S")
        return death_date >= comparison_date
    except (ValueError, TypeError):
        return False

# Load the JSON data
with open('Users_data_April12.json', 'r') as file:
    data = json.load(file)

# Initialize counters
level_stats = {}
#hashmap :
# "Level1": {"wins": 2, "deaths": 0},
# "Level2": {"wins": 1, "deaths": 0}

# Set the comparison date to April 2nd, 2024
comparison_date = datetime(2024, 4, 3)

# Process the wins normally as before
for win_entry in data["winData"].values():
    level = win_entry["levelName"]
    level_stats.setdefault(level, {"wins": 0, "deaths": 0, "# of tries":0}) #hashmap 查看level里面有没有存过这个level,没有就初始化
    level_stats[level]["wins"] += 1
    level_stats[level]["# of tries"] += 1

# Process deaths, excluding those on or before the comparison date and those without a valid date
for death_entry in data["deaths"].values():
    if 'DeathdateTime' in death_entry and is_valid_date_and_after(death_entry["DeathdateTime"], comparison_date):
        level = death_entry["level"]
        level_stats.setdefault(level, {"wins": 0, "deaths": 0, "# of tries":0})
        level_stats[level]["deaths"] += 1
        level_stats[level]["# of tries"] += 1


# Calculate the passing rates
passing_rates = {}
for level, stats in level_stats.items():
    total_attempts = stats["wins"] + stats["deaths"]
    if total_attempts > 0:
        passing_rate = stats["wins"] / total_attempts
    else:
        passing_rate = 0
    passing_rates[level] = passing_rate

print(level_stats)
# Output passing rates

#### using this the draw the graphs
print(passing_rates)



###### 测试日期筛选函数是不是正确的
#
# # Test cases with expected outcomes
# test_cases = [
#     ("2024-04-01 12:00:00", False),  # Before the comparison date
#     ("2024-04-03 12:00:00", True),   # After the comparison date
#     ("", False),                      # Empty string
#     (None, False),                    # None value
#     ("InvalidDate", False),           # Invalid date format
#     # Add more test cases as needed
# ]
#
# # Run the test cases
# for test_date, expected in test_cases:
#     if is_valid_date_and_after(test_date, comparison_date) != expected:
#         print(f"Test failed for date: {test_date}. Expected {expected}.")
#     else:
#         print(f"Test passed for date: {test_date}.")
#

