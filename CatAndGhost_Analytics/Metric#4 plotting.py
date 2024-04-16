import matplotlib.pyplot as plt
def generate_level_graph():
    # Data for the levels
    levels = ['Level 1', 'Level 2', 'Level 3']
    wins = [50, 26, 29]
    deaths = [86, 113, 59]
    win_percentages = [0.3676, 0.1871, 0.3295]

    # Create the bar chart
    fig, ax = plt.subplots()
    width = 0.35  # the width of the bars

    # Bar for wins using a less saturated green
    win_bars = ax.bar(levels, wins, width, label='Wins', color='#b0e57c')  # A pale green color

    # Bar for deaths using a less saturated pink
    death_bars = ax.bar(levels, deaths, width, bottom=wins, label='Deaths', color='#f4c2c2')  # A pale pink color

    # Adding win percentages on the bars
    for i, (win, death) in enumerate(zip(wins, deaths)):
        total = win + death
        percentage = f'{win_percentages[i] * 100:.1f}%'
        ax.text(i, total + 3, percentage, ha='center', color='purple')

    # Set specific labels for the x-axis to ensure "Tutorial" does not show
    ax.set_xticks([0, 1, 2])  # Define ticks for each level
    ax.set_xticklabels(['Level 1', 'Level 2', 'Level 3'])

    # Labels and legends
    ax.set_xlabel('Levels')
    ax.set_ylabel('Counts')
    ax.set_title('Win and Death Counts by Level with Win Percentage')
    ax.legend()

    # Show the plot
    plt.show()

import matplotlib.pyplot as plt

def generate_pie_chart():
    # Data for the pie charts
    data_zero = {
        'Level1': {'same color': 20, 'ghost death': 65, 'longer distance': 23},
        'Level2': {'same color': 22, 'ghost death': 64, 'longer distance': 24},
        'Level3': {'same color': 8, 'ghost death': 46, 'longer distance': 10}
    }

    data_greater_zero = {
        'Level1': {'same color': 41, 'ghost death': 9},
        'Level2': {'same color': 100, 'ghost death': 26},
        'Level3': {'same color': 51, 'ghost death': 2}
    }

    # Define colors for the pie charts
    colors = ['#ff9999', '#66b3ff', '#99ff99', '#ffcc99']

    # Function to plot a pie chart for a specific level
    def plot_pie_chart(data_zero, data_greater_zero, level):
        fig, axs = plt.subplots(1, 2, figsize=(12, 6))
        fig.suptitle(f'Level: {level}', fontsize=16)

        # Plot zero occurrences
        axs[0].pie(data_zero[level].values(), labels=data_zero[level].keys(), autopct='%1.1f%%', startangle=90, colors=colors)
        axs[0].axis('equal')
        axs[0].set_title(f'Zero Occurrences - {level}')

        # Plot occurrences > 0
        axs[1].pie(data_greater_zero[level].values(), labels=data_greater_zero[level].keys(), autopct='%1.1f%%', startangle=90, colors=colors)
        axs[1].axis('equal')
        axs[1].set_title(f'Occurrences > 0 - {level}')

        # Adjust layout
        plt.tight_layout()

        # Show the plot
        plt.show()

    # Plot each level separately
    for level in ['Level1', 'Level2', 'Level3']:
        plot_pie_chart(data_zero, data_greater_zero, level)

if __name__ == '__main__':
    generate_pie_chart()



