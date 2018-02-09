clear all
clc

A = xlsread('处理表（不分管）.xlsx',3);    %读取数据
C = xlsread('处理表（平均值）.xlsx',3);
[row,colum]=size(A);     %A矩阵的行数p，列数q
%A=A+eps;以防有0值出现

S=cov(A);        %样本方差矩阵
R=corrcoef(A);   %样本相关系数数据矩阵
[V,D]=eig(R);    %样本相关系数数据矩阵的特征值D（对角线矩阵）和特征向量V

O=ones(colum,1);     %将D对角线矩阵 转化为列向量F
F=D*O;
m=sum(F,1);      %求特征值之和
for i=1:colum        %特征值的标记
    F(i,2)=i;
end
H=sortrows(F,-1);      %特征值矩阵按从大到小排序

sum=0;
for i=1:colum              %顺延 贡献率 累计贡献率
    H(i,3)=H(i,1)/m;
    sum=sum+H(i,1)/m;
    H(i,4)=sum;
end

L=[];            %累计贡献率达到0.8的主成分
i=1;
while H(i,4)<0.8
    L(i,:)=H(i,:);
    i=i+1;
end
    L(i,:)=H(i,:);  %i为L中的行数，即选出的特征向量的个数
   
E=[];           %给出相应与L中的特征值的特征向量矩阵
for j=1:i
    E(:,j)=V(:,L(j,2));
end
Sch=Schmidt(E);     %Schmidt正交单位化
%由于第一个特征向量贡献率高达50%以上，所以取第一个标准化指标的样本
Y(:,1)=Sch(:,1);

X=[];
for i=1:colum       %标准化指标的值的矩阵
    X(:,i)=(A(:,i)-C(1,i))./sqrt(S(i,i));
end

B=X*Y;               %按第一主成分y每个人得分
for i=1:row        %人员的标记
    B(i,2)=i;
end
T=sortrows(B,-1);    %人员按从大到小排序

xlswrite('主成分排名.xlsx',T,3);
