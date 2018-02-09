clear all
clc

[~,~,total_data] = xlsread('ProblemCData','A2:D105745');    %��ȡ����
[total_row,total_colum]=size(total_data);
A = zeros(4,605);

counter = 1;
for i = 1:total_row
    if total_data{i,3} == 2009
        if strcmp(total_data{i,2},'AZ') == 1
            A(1,counter) = cell2mat(total_data(i,4));
        elseif strcmp(total_data{i,2},'CA') == 1
            A(2,counter) = cell2mat(total_data(i,4));
        elseif strcmp(total_data{i,2},'NM') == 1
            A(3,counter) = cell2mat(total_data(i,4));
        elseif strcmp(total_data{i,2},'TX') == 1 
            A(4,counter) = cell2mat(total_data(i,4));
            counter = counter + 1;
        end
    end
end

[row,colum]=size(A);     %A���������p������q
A=A+1;%�Է���0ֵ����

[pc,score,latent,tsquare] = princomp(A); 
pc
% 
% S=cov(A);        %�����������
% R=corrcoef(A);   %�������ϵ�����ݾ���
% %eps = 0.001*ones(colum,colum);
% %R=R+eps;
% [V,D]=eig(R);    %�������ϵ�����ݾ��������ֵD���Խ��߾��󣩺���������V
% 
% O=ones(colum,1);     %��D�Խ��߾��� ת��Ϊ������F
% F=D*O;
% m=sum(F,1);      %������ֵ֮��
% for i=1:colum        %����ֵ�ı��
%     F(i,2)=i;
% end
% H=sortrows(F,-1);      %����ֵ���󰴴Ӵ�С����
% 
% sum=0;
% for i=1:colum              %˳�� ������ �ۼƹ�����
%     H(i,3)=H(i,1)/m;
%     sum=sum+H(i,1)/m;
%     H(i,4)=sum;
% end
% 
% L=[];            %�ۼƹ����ʴﵽ0.8�����ɷ�
% i=1;
% while H(i,4)<0.8
%     L(i,:)=H(i,:);
%     i=i+1;
% end
%     L(i,:)=H(i,:);  %iΪL�е���������ѡ�������������ĸ���
%    
% E=[];           %������Ӧ��L�е�����ֵ��������������
% for j=1:i
%     E(:,j)=V(:,L(j,2));
% end
% Sch=Schmidt(E);     %Schmidt������λ��
% %���ڵ�һ���������������ʸߴ�50%���ϣ�����ȡ��һ����׼��ָ�������
% Y(:,1)=Sch(:,1);
% 
% X=[];
% for i=1:colum       %��׼��ָ���ֵ�ľ���
%     X(:,i)=(A(:,i)-C(1,i))./sqrt(S(i,i));
% end
% 
% B=X*Y;               %����һ���ɷ�yÿ���˵÷�
% for i=1:row        %��Ա�ı��
%     B(i,2)=i;
% end
% T=sortrows(B,-1);    %��Ա���Ӵ�С����
% 
% xlswrite('���ɷ�����.xlsx',T,3);
