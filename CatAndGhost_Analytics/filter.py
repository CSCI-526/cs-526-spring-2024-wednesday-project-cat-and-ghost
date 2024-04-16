import json
from datetime import datetime

# Load the original JSON data
with open('Users_data_April12.json', 'r') as file:
    data = json.load(file)

# Filter out deaths without a date and before April 3rd, 2024
filtered_deaths = {}

for death_id, death_data in data['deaths'].items():
    death_date_str = death_data.get('DeathdateTime')
    if death_date_str:
        death_date = datetime.strptime(death_date_str, "%Y-%m-%d %H:%M:%S")
        if death_date >= datetime(2024, 4, 3):
            filtered_deaths[death_id] = death_data

# Print the filtered data to check if it's empty or not
print("Filtered Deaths:", filtered_deaths)

# Save the filtered data to a new JSON file
with open('filtered_data.json', 'w') as file:
    json.dump(filtered_deaths, file, indent=4)
