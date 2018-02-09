data_dir = '..\ProblemCData.xlsx';
[num_m,txt_m,raw_m] = xlsread(data_dir);

raw_m = raw_m(2:end,:);
[raw_m_len,~] = size(raw_m);

data = importdata('transportation_consumption.txt');
total_consumption_len = length(data);
A = zeros(50,4,total_consumption_len);
for i = 1:raw_m_len
    for j = 1:total_consumption_len
        if strcmp(raw_m{i,1},data(j))
            if strcmp(raw_m{i,2},'AZ')
            	A(raw_m{i,3}-1959,1,j) = raw_m{i,4};
            elseif strcmp(raw_m{i,2},'CA')
            	A(raw_m{i,3}-1959,2,j) = raw_m{i,4};
            elseif strcmp(raw_m{i,2},'NM')
            	A(raw_m{i,3}-1959,3,j) = raw_m{i,4};
            elseif strcmp(raw_m{i,2},'TX')
            	A(raw_m{i,3}-1959,4,j) = raw_m{i,4};
            end
        end
    end
end

B = [];
for i = 1:total_consumption_len
    B = [B;A(:,:,i)];
end