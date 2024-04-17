# import matplotlib.pyplot as plt
# def generate_level_graph():
#     # Data for the levels
#     levels = ['Level 1', 'Level 2', 'Level 3']
#     wins = [50, 26, 29]
#     deaths = [86, 113, 59]
#     win_percentages = [0.3676, 0.1871, 0.3295]
#
#     # Create the bar chart
#     fig, ax = plt.subplots()
#     width = 0.35  # the width of the bars
#
#
#     # Bar for wins using a less saturated green
#     win_bars = ax.bar(levels, wins, width, label='Wins', color='#b0e57c')  # A pale green color
#
#     # Bar for deaths using a less saturated pink
#     death_bars = ax.bar(levels, deaths, width, bottom=wins, label='Deaths', color='#f4c2c2')  # A pale pink color
#
#     # Adding win percentages on the bars
#     for i, (win, death) in enumerate(zip(wins, deaths)):
#         total = win + death
#         percentage = f'{win_percentages[i] * 100:.1f}%'
#         ax.text(i, total + 3, percentage, ha='center', color='purple')
#
#     # Set specific labels for the x-axis to ensure "Tutorial" does not show
#     ax.set_xticks([0, 1, 2])  # Define ticks for each level
#     ax.set_xticklabels(['Level 1', 'Level 2', 'Level 3'])
#
#     # Labels and legends
#     ax.set_xlabel('Levels')
#     ax.set_ylabel('Counts')
#     ax.set_title('Win and Death Counts by Level with Win Percentage')
#     ax.legend()
#
#     # Increase the height of the y-axis
#     ax.set_ylim(0, max(wins) + max(deaths) + 20)  # Adjust the upper limit for the y-axis
#     # Show the plot
#     plt.show()
#
# if __name__ == '__main__':
#     generate_level_graph()
#
#

import matplotlib.pyplot as plt
import numpy as np

def generate_level_graph():
    # Data for the levels
    levels = ['Level 1', 'Level 2', 'Level 3']
    wins = [50, 26, 29]
    deaths = [86, 113, 59]
    win_percentages = [0.3676, 0.1871, 0.3295]

    # Create the bar chart for wins and deaths
    fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(12, 6))

    # Width of the bars
    width = 0.35

    # Bar for wins using a less saturated green
    win_bars = ax1.bar(levels, wins, width, label='Wins', color='#b0e57c')  # A pale green color

    # Bar for deaths using a less saturated pink
    death_bars = ax1.bar(levels, deaths, width, bottom=wins, label='Deaths', color='#f4c2c2')  # A pale pink color

    # # Adding win percentages on the bars
    # for i, (win, death) in enumerate(zip(wins, deaths)):
    #     total = win + death
    #     percentage = f'{win_percentages[i] * 100:.1f}%'
    #     ax1.text(i, total + 3, percentage, ha='center', color='purple')

    # Set specific labels for the x-axis to ensure "Tutorial" does not show
    ax1.set_xticks([0, 1, 2])  # Define ticks for each level
    ax1.set_xticklabels(['Level 1', 'Level 2', 'Level 3'])

    # Labels and legends for the first plot
    ax1.set_xlabel('Levels')
    ax1.set_ylabel('Counts')
    ax1.set_title('Win and Death Counts')
    ax1.legend()

    # Increase the height of the y-axis
    ax1.set_ylim(0, max(wins) + max(deaths) + 20)  # Adjust the upper limit for the y-axis

    # Generate the percentage scatter plot with connecting lines
    generate_percentage_graph(win_percentages, ax2)

    # Show the plot
    plt.tight_layout()
    plt.show()

def generate_percentage_graph(win_percentages, ax):
    # Data for the win percentages
    levels = ['Level 1', 'Level 2', 'Level 3']

    # Scatter plot for win percentages
    ax.scatter(levels, win_percentages, color='skyblue')

    # Draw lines connecting consecutive points
    for i in range(len(levels) - 1):
        ax.plot([levels[i], levels[i+1]], [win_percentages[i], win_percentages[i+1]], color='gray', linestyle='-', linewidth=1)

    # Adding win percentages on the scatter points
    for i, percentage in enumerate(win_percentages):
        ax.text(levels[i], percentage + 0.01, f'{percentage * 100:.1f}%', ha='center', color='black')

    # Labels and title for the second plot
    ax.set_xlabel('Levels')
    ax.set_ylabel('Win Percentage')
    ax.set_title('Pass Percentage by Level')

if __name__ == '__main__':
    generate_level_graph()
