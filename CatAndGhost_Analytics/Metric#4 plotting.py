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

# change or not change color count pie chart
def levels_pie_chart():
    # Data for the pie charts
    data_zero = {
        'Level1': {'zero': 20, 'greater_zero': 65},
        'Level2': {'zero': 22, 'greater_zero': 64},
        'Level3': {'zero': 8, 'greater_zero': 46}
    }

    data_greater_zero = {
        'Level1': {'zero': 41, 'greater_zero': 9},
        'Level2': {'zero': 100, 'greater_zero': 26},
        'Level3': {'zero': 51, 'greater_zero': 2}
    }

    # Define colors for the pie charts
    colors = ['#ff9999', '#66b3ff']

    # Function to plot a pie chart for a specific level
    def plot_pie_chart(data_zero, data_greater_zero, level, ax):
        # Plot zero and greater_zero occurrences
        ax.pie(data_zero[level].values(), labels=data_zero[level].keys(), autopct='%1.1f%%', startangle=90, colors=colors)
        ax.set_title(f'Level: {level} - Zero Occurrences')

        ax2 = ax.twinx()  # instantiate a second axes that shares the same x-axis
        ax2.pie(data_greater_zero[level].values(), labels=data_greater_zero[level].keys(), autopct='%1.1f%%', startangle=90, colors=colors)
        ax2.set_title(f'Level: {level} - Greater Zero Occurrences')

    # Plot each level separately
    fig, axs = plt.subplots(1, 3, figsize=(18, 6))

    for i, level in enumerate(['Level1', 'Level2', 'Level3']):
        plot_pie_chart(data_zero, data_greater_zero, level, axs[i])

    # Adjust layout
    plt.tight_layout()

    # Show the plot
    plt.show()

if __name__ == '__main__':
    levels_pie_chart()



