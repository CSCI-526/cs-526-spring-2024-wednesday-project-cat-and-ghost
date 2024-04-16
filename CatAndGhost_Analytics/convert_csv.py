import csv
import json

# Load the JSON data
with open('filtered_data.json', 'r') as file:
    data = json.load(file)

# Define the fieldnames for the CSV file
fieldnames = ["id", "DeathdateTime", "endTime", "killedBy", "level", "positionX", "positionY"]

# Open the CSV file in write mode
with open('filtered_death.csv', 'w', newline='') as csvfile:
    # Create a CSV writer object
    writer = csv.DictWriter(csvfile, fieldnames=fieldnames)

    # Write the header row
    writer.writeheader()

    # Write each row of data
    for item_id, item_data in data.items():
        # Replace the key with the value of the "id" field
        item_data["id"] = item_id
        writer.writerow(item_data)