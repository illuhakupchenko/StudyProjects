# программа не запускается в PyCharm, нужно запускать файл через консоль
# ctrl + c - остановить выполнение программы в косноли

import telebot

bot = telebot.TeleBot("801359509:AAHjuBl_1xRdDHHTTacpT3Q1TSiXl_qQiCw")

@bot.message_handler(content_types=['text'])
def send_echo(message):
	bot.send_message(message.chat.id, message.text)

bot.polling( none_stop = True)