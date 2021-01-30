'''
print("Дароу!")
txt = input("Введіть зашифрований текст:\n")

alphabet = ['а', 'б', 'в', 'г', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
            'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я']

#maxcount = 0
#maxcount1 = 0

#for item in txt:
    #maxcount = 0
    #for item1 in txt:
        #if item == item1 and str(item) != ' ' and str(item) != '\n':
           #maxcount += 1
    #if maxcount > maxcount1:
        #maxcount1 = maxcount
        #nm = item #підрахунок найбільш повторюваної літери

#print(maxcount1)
#print(nm)

#print(alphabet.index(nm))

txt1 = ''
try:
    for item in txt:
        if str(item) != ' ' and str(item) != '\n' and str(item) != ',' and str(item) != '.':
            if 3 > alphabet.index(item) >= 0:
                item = alphabet[32 + alphabet.index(item) - 3]
            elif alphabet.index(item) - 4 < 0:
                item = alphabet[32 + alphabet.index(item) - 4]
            else:
                item = alphabet[alphabet.index(item)-4]
        txt1 += item
except:
    print("Вводити можна лише літери українського алфавіту!")
print(txt1)
'''

alphabet = ['а', 'б', 'в', 'г', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
            'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я']

'''try: #2, 6
    for item in txt:
        if str(item) != ' ' and str(item) != '\n' and str(item) != ',' and str(item) != '.':
            if 3 > alphabet.index(item) >= 0:
                item = alphabet[32 + alphabet.index(item) - 3]
            elif alphabet.index(item) - 4 < 0:
                item = alphabet[32 + alphabet.index(item) - 4]
            else:
                item = alphabet[alphabet.index(item)-4]
        txt1 += item
except:
    print("Вводити можна лише літери українського алфавіту!")'''

'''try: #1
    for item in txt:
        if str(item) != ' ' and str(item) != '\n' and str(item) != ',' and str(item) != '.':
            if 1 > alphabet.index(item) >= 0:
                item = alphabet[32 + alphabet.index(item) - 1]
            elif alphabet.index(item) - 2 < 0:
                item = alphabet[32 + alphabet.index(item) - 2]
            else:
                item = alphabet[alphabet.index(item)-2]
        txt1 += item
except:
    print("Вводити можна лише літери українського алфавіту!")'''

'''try: #3
    for item in txt:
        if str(item) != ' ' and str(item) != '\n' and str(item) != ',' and str(item) != '.':
            if 5 > alphabet.index(item) >= 0:
                item = alphabet[32 + alphabet.index(item) - 5]
            elif alphabet.index(item) - 2 < 0:
                item = alphabet[32 + alphabet.index(item) - 6]
            else:
                item = alphabet[alphabet.index(item)-6]
        txt1 += item
except:
    print("Вводити можна лише літери українського алфавіту!")'''
'''try: #4
    for item in txt:
        if str(item) != ' ' and str(item) != '\n' and str(item) != ',' and str(item) != '.':
            if 2 > alphabet.index(item) >= 0:
                item = alphabet[32 + alphabet.index(item) - 2]
            elif alphabet.index(item) - 1 < 0:
                item = alphabet[32 + alphabet.index(item) - 3]
            else:
                item = alphabet[alphabet.index(item)-3]
        txt1 += item
except:
    print("Вводити можна лише літери українського алфавіту!")'''
'''try: #5
    for item in txt:
        if str(item) != ' ' and str(item) != '\n' and str(item) != ',' and str(item) != '.':
            if 7 > alphabet.index(item) >= 0:
                item = alphabet[32 + alphabet.index(item) - 7]
            elif alphabet.index(item) - 7 < 0:
                item = alphabet[32 + alphabet.index(item) - 8]
            else:
                item = alphabet[alphabet.index(item)-8]
        txt1 += item
except:
    print("Вводити можна лише літери українського алфавіту!")'''

print('Привіт!\nВведіть зашифрований текст, а після цього для запуску процесу дешифровки введіть з '
      'нового рядка ключове слово "погнали"')

data1 = ''


def let_do_it():
    txt = ''
    txt1 = ''
    while True:
        data1 = input()
        if data1 == 'погнали':
            break
        txt += data1 + '\n'

    yourkey = int(input("Введіть ключ дешифровки: "))

    for item in txt:
        if str(item) in alphabet:
            if yourkey - 1 > alphabet.index(item) >= 0:
                item = alphabet[32 + alphabet.index(item) - yourkey + 1]
            elif alphabet.index(item) - yourkey + 1 <= 0:
                item = alphabet[32 + alphabet.index(item) - yourkey]
            else:
                item = alphabet[alphabet.index(item) - yourkey]
        txt1 += item
    return txt1


print(let_do_it())

while True:
    more = input("Бажаєте розшифрувати щось ще?(так/ні)")
    if str(more) == "ТАК".lower() or str(more) == "ДА".lower():
        print('Введіть зашифрований текст, а після цього для запуску процесу дешифровки введіть з нового рядка '
              'ключове слово "погнали"')
        print(let_do_it())
    else:
        break
