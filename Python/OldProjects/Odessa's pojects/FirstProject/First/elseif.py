num = input("Введите число: ")

if int(num) > 0:
    if int(num) > 10:
        print("You entered num bigger 10")
    else:
        print("You entered numb less 10")
elif int(num) < -10:
    print("You entered numb less -10")
else:
    print("You entered numb less 0 & bigger -10")
print("All is okay!")

name = input()
A = 'Yes' if name != "Test" else 'No'
print(A)