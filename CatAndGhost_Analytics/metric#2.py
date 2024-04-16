import json
from datetime import datetime
from PIL import Image

# Load the existing image
existing_image = Image.open('level1.jpg')

# Load the data from the file
with open('Users_data_April12.json', 'r') as file:
    data = json.load(file)

# Define the comparison date
comparison_date = datetime(2024, 4, 3)

# Initialize lists for plotting
x_nail = []
y_nail = []
x_ghost = []
y_ghost = []

# Process the data
for death in data['deaths'].values():
    death_date_str = death.get('DeathdateTime')
    if death_date_str:
        death_date = datetime.strptime(death_date_str, "%Y-%m-%d %H:%M:%S")
        if death_date >= comparison_date and death['level'] == 'Level3':
            if death['killedBy'] == 'Nail':
                x_nail.append(death['positionX'])
                y_nail.append(death['positionY'])
            elif death['killedBy'] == 'Ghost':
                x_ghost.append(death['positionX'])
                y_ghost.append(death['positionY'])

print("x_nail:",x_nail)
print("y_nail:",y_nail)
print("x_ghost:",x_ghost)
print("y_ghost:",y_ghost)

# # Plotting
# plt.figure(figsize=(18, 10))  # Set the size of the plot to match the border size
# plt.scatter(x_nail, y_nail, c='red', label='Killed by Nail')  # Red for Nail deaths
# plt.scatter(x_ghost, y_ghost, c='blue', label='Killed by Ghost')  # Blue for Ghost deaths
# plt.axhline(0, color='grey', lw=1)  # Draw x-axis
# plt.axvline(0, color='grey', lw=1)  # Draw y-axis
# plt.xlim(-9, 9)  # Set x-axis limits to -9 and 9 (-18/2 to 18/2)
# plt.ylim(-5, 5)  # Set y-axis limits to -5 and 5 (-10/2 to 10/2)
# plt.legend()
# plt.title('Player Deaths in Level 1')
# plt.xlabel('Position X')
# plt.ylabel('Position Y')
# plt.grid(True)
# plt.show()

# # Plotting
# plt.figure(figsize=(14.36, 7.68))  # Set the size of the plot to match the game's aspect ratio
# plt.scatter(x_nail, y_nail, c='red', label='Killed by Nail')  # Red for Nail deaths
# plt.scatter(x_ghost, y_ghost, c='blue', label='Killed by Ghost')  # Blue for Ghost deaths
# plt.axhline(0, color='grey', lw=1)  # Draw x-axis
# plt.axvline(0, color='grey', lw=1)  # Draw y-axis
# plt.legend()
# plt.title('Player Deaths in Level 1')
# plt.xlabel('Position X')
# plt.ylabel('Position Y')
# plt.xlim(-960, 960)  # Set the limits for x-axis
# plt.ylim(-540, 540)  # Set the limits for y-axis
# plt.grid(True)
# plt.show()