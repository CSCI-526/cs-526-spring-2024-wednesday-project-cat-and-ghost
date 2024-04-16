import json
from datetime import datetime

def load_data():
    with open('Users_data_April12.json', 'r') as file:
        return json.load(file)

def is_valid_date(date_str):
    try:
        datetime.strptime(date_str, "%Y-%m-%d %H:%M:%S")
        return True
    except (ValueError, TypeError):
        return False

def process_events(data):
    stats_by_date_level = {}
    # 设置比较日期
    comparison_date = datetime(2024, 4, 3).date()

    # 处理赢的数据
    for win_entry in data["winData"].values():
        date_str = win_entry.get("winDateTime", "")
        level = win_entry.get("levelName", "")
        if is_valid_date(date_str):
            win_date = datetime.strptime(date_str, "%Y-%m-%d %H:%M:%S").date()
            if win_date not in stats_by_date_level:
                stats_by_date_level[win_date] = {}
            if level not in stats_by_date_level[win_date]:
                stats_by_date_level[win_date][level] = {'wins': 0, 'deaths': 0}
            stats_by_date_level[win_date][level]['wins'] += 1

    # 处理输的数据
    for death_entry in data["deaths"].values():
        date_str = death_entry.get("DeathdateTime", "")
        level = death_entry.get("level", "")
        if is_valid_date(date_str):
            death_date = datetime.strptime(date_str, "%Y-%m-%d %H:%M:%S").date()
            if death_date > comparison_date:
                if death_date not in stats_by_date_level:
                    stats_by_date_level[death_date] = {}
                if level not in stats_by_date_level[death_date]:
                    stats_by_date_level[death_date][level] = {'wins': 0, 'deaths': 0}
                stats_by_date_level[death_date][level]['deaths'] += 1

    return stats_by_date_level

def print_stats(stats_by_date_level):
    for date, levels in sorted(stats_by_date_level.items()):
        print(f"Date: {date}")
        for level, stats in levels.items():
            print(f"  Level: {level}, Wins: {stats['wins']}, Deaths: {stats['deaths']}")

# 主逻辑
data = load_data()
stats_by_date_level = process_events(data)
print_stats(stats_by_date_level)
