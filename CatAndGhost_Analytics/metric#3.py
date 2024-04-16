import json
import pandas as pd
import matplotlib.pyplot as plt

# Load the JSON data
with open('Users_data_April12.json', 'r') as file:
    data = json.load(file)

# Initialize a dictionary to store the count of each checkpoint for Level3
checkpoint_counts = {}

# Iterate over the data to count the occurrences of each checkpoint for Level3
for item_data in data['CheckpointData'].values():
    level = item_data['levelName']
    checkpoint = item_data['Checkpoint']
    if level == "Level3":
        # If the level is not already in the dictionary, initialize it with an empty dictionary
        if level not in checkpoint_counts:
            checkpoint_counts[level] = {}

        # Increment the count for the checkpoint within Level3
        if checkpoint in checkpoint_counts[level]:
            checkpoint_counts[level][checkpoint] += 1
        else:
            checkpoint_counts[level][checkpoint] = 1

# Convert the dictionary into a DataFrame for easier manipulation and plotting
df = pd.DataFrame(checkpoint_counts)

# Plotting
ax = df.plot(kind='bar', stacked=True)
# plt.xlabel('Checkpoint')
plt.ylabel('Count')
plt.title('Occurrences of Checkpoints in Level3')
plt.xticks(rotation=0)
plt.legend(title='Checkpoint')

# Annotate each bar with its count
for p in ax.patches:
    ax.annotate(str(p.get_height()), (p.get_x() + p.get_width() / 2., p.get_height()),
                ha='center', va='center', xytext=(0, 5), textcoords='offset points')

plt.tight_layout()
plt.show()
