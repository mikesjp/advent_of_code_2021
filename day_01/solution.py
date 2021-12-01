def get_total_number_of_sums_larger_than_prev(arr):
    counter = 0
    for i in range(1, len(arr)):
        if arr[i] > arr[i - 1]:
            counter += 1
    return counter


with open('puzzle_input.txt', 'r') as input:
    depths = []
    for line in input:
        depths.append(int(line.strip()))

# Part 1
print(get_total_number_of_sums_larger_than_prev(depths))

# Part 2
sums = []
for i in range(len(depths)):
    sums.append(sum(depths[i: i + 3]))

print(get_total_number_of_sums_larger_than_prev(sums))
