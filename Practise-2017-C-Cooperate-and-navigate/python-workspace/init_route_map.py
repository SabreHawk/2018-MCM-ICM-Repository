#!/usr/bin/env python3
# -*- coding: utf-8 -*-

#init route map of the four road by mileposts
from pyecharts import Line


class cross_point:
    def __init__(self, x=0, y=0, self_num=0, target_num=0):
        self.x = x
        self.y = y
        self.self_num = self_num
        self.target_num = target_num



res_path = '/home/zhiquanwang/CodeRepository/2018-MCM-ICM-Repository/Practise-2017-C-Cooperate-and-navigate/resource/'
file_name = 'milepost_pos.txt'
# Address Mileposts Position Data
road_5_points = []
road_90_points = []
road_405_points = []
road_520_points = []

cross_points = []
with open(res_path+file_name, 'r') as pos_file:
    pos_data = pos_file.read()

cur_num = -1
temp_cross_point = cross_point()
for line in pos_data.splitlines():

    temp_line = line.split()
    # print(temp_line)
    if temp_line[0] == '#':
        cur_num = int(temp_line[1])
        print("Start Record Road " + str(cur_num) + ":")
        continue
    else:
        temp_x = int(temp_line[0])
        temp_y = int(temp_line[1])
    temp_pos = []
    temp_pos.append(temp_x)
    temp_pos.append(temp_y)
    if cur_num == 5:
        road_5_points.append(temp_pos)
    elif cur_num == 90:
        road_90_points.append(temp_pos)
    elif cur_num == 405:
        road_405_points.append(temp_pos)
    elif cur_num == 520:
        road_520_points.append(temp_pos)

    if temp_line.count ==3 and temp_line[2][0] == '-':
        temp_cross_point.x = temp_x
        temp_cross_point.y = temp_y
        temp_cross_point.self_num = cur_num
        temp_cross_point.target_num = int(temp_line[2][1:])
        if(cross_points.count(temp_cross_point) != 0):
            cross_points.append(temp_cross_point)

#Init Route Map

attr = ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
v1 = [5, 20, 36, 10, 10, 100]
v2 = [55, 60, 16, 20, 15, 80]
line = Line("折线图示例")
line.add("商家A", attr, v1, mark_point=["average"])
line.add("商家B", attr, v2, is_smooth=True, mark_line=["max", "average"])
line.render()