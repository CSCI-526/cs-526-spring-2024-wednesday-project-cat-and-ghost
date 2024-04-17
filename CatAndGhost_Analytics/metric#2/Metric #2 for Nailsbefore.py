import json
from datetime import datetime
from PIL import Image

# Load the existing image
existing_image = Image.open('../level1.jpg')

# Load the data from the file
with open('NailsBefore.json', 'r') as file:
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
        # if death_date >= comparison_date and death['level'] == 'Level1':
    if death['level'] == 'Level1':

        if death['killedBy'] == 'Nail':
            x_nail.append(death['positionX'])
            y_nail.append(death['positionY'])
        elif death['killedBy'] == 'Ghost':
            x_ghost.append(death['positionX'])
            y_ghost.append(death['positionY'])

print("x_nail=",x_nail)
print("y_nail=",y_nail)
print("x_ghost=",x_ghost)
print("y_ghost=",y_ghost)