# import matplotlib.pyplot as plt
#
# def generate_pie_chart():
#     # Data for the pie charts
#     data_zero = {
#         'Level1': {'same color': 20, 'ghost death': 65, 'longer distance': 23},
#         'Level2': {'same color': 22, 'ghost death': 64, 'longer distance': 24},
#         'Level3': {'same color': 8, 'ghost death': 46, 'longer distance': 10}
#     }
#
#     data_greater_zero = {
#         'Level1': {'same color': 41, 'ghost death': 9},
#         'Level2': {'same color': 100, 'ghost death': 26},
#         'Level3': {'same color': 51, 'ghost death': 2}
#     }
#
#     # Calculate total zero and greater_zero for each level
#     total_zero = {}
#     total_greater_zero = {}
#
#     for level in data_zero:
#         total_zero[level] = sum(data_zero[level].values())
#         total_greater_zero[level] = sum(data_greater_zero[level].values())
#
#     print("total_zero:",total_zero)
#     print("total_greater_zero:",total_greater_zero)
#
#     # Define colors for the pie charts
#     colors = ['#ff9999', '#66b3ff']
#
#     # Function to plot a pie chart for a specific level
#     def plot_pie_chart(data_zero, data_greater_zero, level, ax):
#         zero_values = list(data_zero[level].values())
#         greater_zero_values = list(data_greater_zero[level].values())
#
#         # Plot zero and greater_zero occurrences
#         ax.pie(zero_values, labels=[f'{val} ({zero_values[i]/total_zero[level]*100:.1f}%)' for i, val in enumerate(zero_values)], autopct='', startangle=90, colors=colors)
#         ax.set_title(f'Level: {level} - Zero Occurrences')
#
#         ax2 = ax.twinx()  # instantiate a second axes that shares the same x-axis
#         ax2.pie(greater_zero_values, labels=[f'{val} ({greater_zero_values[i]/total_greater_zero[level]*100:.1f}%)' for i, val in enumerate(greater_zero_values)], autopct='', startangle=90, colors=colors)
#         ax2.set_title(f'Level: {level} - Greater Zero Occurrences')
#
#     # Plot each level separately
#     fig, axs = plt.subplots(1, 3, figsize=(18, 6))
#
#     for i, level in enumerate(['Level1', 'Level2', 'Level3']):
#         plot_pie_chart(data_zero, data_greater_zero, level, axs[i])
#
#     # Adjust layout
#     plt.tight_layout()
#
#     # Show the plot
#     plt.show()
#
# if __name__ == '__main__':
#     generate_pie_chart()

import matplotlib.pyplot as plt

def generate_pie_chart(total_zero, total_greater_zero):
    # Define colors for the pie charts
    colors = ['#ff9999', '#66b3ff']

    # Function to plot a pie chart for a specific level
    def plot_pie_chart(level, total_zero, total_greater_zero, ax):
        # Plot zero and greater_zero occurrences
        ax.pie([total_zero[level], total_greater_zero[level]], labels=[f'Changed Color\n({total_zero[level]})', f'Did Not Changed\nColor ({total_greater_zero[level]})'], autopct='%1.1f%%', startangle=90, colors=colors)
        ax.set_title(f'Level: {level}')

    # Plot each level separately
    fig, axs = plt.subplots(2, 2, figsize=(10, 10))

    for i, level in enumerate(['Level1', 'Level2', 'Level3']):
        if i < 2:
            plot_pie_chart(level, total_zero, total_greater_zero, axs[0, i])
        else:
            plot_pie_chart(level, total_zero, total_greater_zero, axs[1, 1])

    # Adjust layout
    plt.tight_layout()

    # Show the plot
    plt.show()

if __name__ == '__main__':
    total_zero = {'Level1': 108, 'Level2': 110, 'Level3': 64}
    total_greater_zero = {'Level1': 50, 'Level2': 126, 'Level3': 53}
    generate_pie_chart(total_zero, total_greater_zero)
