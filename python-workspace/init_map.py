from pyecharts import Bar3D
from pyecharts import Line3D
from pyecharts import Page
import os

current_path = os.getcwd()
parent_path = os.path.dirname(current_path)
res_path = os.path.join(parent_path,'resource/data.txt')

# Read Data
with open(res_path, 'r') as data_file:
    data_raw = data_file.read()

state_num = 4
year_num = 50
label_num = 29
data_matrix = [[],[],[],[]]
label_counter = 0
year_counter = 0

for line in data_raw.splitlines():
    temp_line = line.split()
    for i in range(4):
        data_matrix[i].append([label_counter,year_counter,float(temp_line[i])])
  
    year_counter = year_counter + 1
    if year_counter == 50:
        label_counter = label_counter + 1
        year_counter = 0

page = Page()
# Draw Map
x_axis = [i for i in range(26)]
y_axis = [i for i in range(1960,2010)]
line3d_00 = Bar3D("",width=1600, height=1000)
img_name = 'Total Consumption Of Each Type Of Energy In-Arizona'
range_color = ['#313695', '#4575b4', '#74add1', '#abd9e9', '#e0f3f8', '#ffffbf','#fee090', '#fdae61', '#f46d43', '#d73027', '#a50026']
line3d.add(img_name, x_axis, y_axis, [[d[0],d[1],d[2]]for d in data_matrix[0]],x_axis_name='energy type',y_axis_name='year',z_axis_name='Billion Btu', grid3d_opacity=0.8,is_visualmap=True,visual_range=[0, 1500000],
          visual_range_color=range_color)
page.add(line3d_00)

x_axis = [i for i in range(26)]
y_axis = [i for i in range(1960,2010)]
line3d_01 = Bar3D("",width=1600, height=1000)
img_name = 'Total Consumption Of Each Type Of Energy In-Arizona'
range_color = ['#313695', '#4575b4', '#74add1', '#abd9e9', '#e0f3f8', '#ffffbf','#fee090', '#fdae61', '#f46d43', '#d73027', '#a50026']
line3d.add(img_name, x_axis, y_axis, [[d[0],d[1],d[2]]for d in data_matrix[1]],x_axis_name='energy type',y_axis_name='year',z_axis_name='Billion Btu', grid3d_opacity=0.8,is_visualmap=True,visual_range=[0, 1500000],
          visual_range_color=range_color)
page.add(line3d_01)

x_axis = [i for i in range(26)]
y_axis = [i for i in range(1960,2010)]
line3d_02 = Bar3D("",width=1600, height=1000)
img_name = 'Total Consumption Of Each Type Of Energy In-Arizona'
range_color = ['#313695', '#4575b4', '#74add1', '#abd9e9', '#e0f3f8', '#ffffbf','#fee090', '#fdae61', '#f46d43', '#d73027', '#a50026']
line3d.add(img_name, x_axis, y_axis, [[d[0],d[1],d[2]]for d in data_matrix[2]],x_axis_name='energy type',y_axis_name='year',z_axis_name='Billion Btu', grid3d_opacity=0.8,is_visualmap=True,visual_range=[0, 1500000],
          visual_range_color=range_color)
page.add(line3d_02)

x_axis = [i for i in range(26)]
y_axis = [i for i in range(1960,2010)]
line3d_03 = Bar3D("",width=1600, height=1000)
img_name = 'Total Consumption Of Each Type Of Energy In-Arizona'
range_color = ['#313695', '#4575b4', '#74add1', '#abd9e9', '#e0f3f8', '#ffffbf','#fee090', '#fdae61', '#f46d43', '#d73027', '#a50026']
line3d.add(img_name, x_axis, y_axis, [[d[0],d[1],d[2]]for d in data_matrix[3]],x_axis_name='energy type',y_axis_name='year',z_axis_name='Billion Btu', grid3d_opacity=0.8,is_visualmap=True,visual_range=[0, 1500000],
          visual_range_color=range_color)
page.add(line3d_03) 

page.render()