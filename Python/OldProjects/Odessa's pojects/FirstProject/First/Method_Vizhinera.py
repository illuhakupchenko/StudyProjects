from string import ascii_lowercase

print('Привіт!\nВведіть зашифрований текст, а після цього для запуску процесу дешифровки введіть з нового рядка ключове слово "погнали"')


'''txtString = ''
while True:
    data = input()
    if data == 'погнали':
        break
    txtString += data + '\n'

str1 = txtString
str2 = txtString
j = 0
while True:
    str2.replace()

i = 0
k = 0

while i < len(txtString):
    if str1[i] != '\n' and str1[i] == str2[i]:
        k += 1
    i += 1

print(k)'''

txt = ''
txt1 = ''
while True:
    data1 = input()
    if data1 == 'погнали':
        break
    txt += data1 + '\n'

def met(string, key):
    output = ''
    key_possitions = []
    for x in key:
        key_possitions.append(ascii_lowercase.find(x))
    i = 0
    for x in string:
        if i == len(key_possitions):
            i = 0
        possition = ascii_lowercase.find(x) + key_possitions[i]
        if possition > 25:
            possition = possition - 26
        output += ascii_lowercase[possition].capitalize()
        i += 1
    return output

print(met(txt, "дкек"))