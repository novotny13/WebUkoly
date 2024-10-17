# -*- coding: utf-8 -*-


import asyncio
import websockets
import random


jokes = [
    "Why was the math book sad? It had too many problems.",
    "What do you call fake spaghetti? An impasta!",
    "Why do programmers prefer dark mode? Because light attracts bugs.",
    "Why did the computer go to the doctor? It had a virus!",
    "What is a programmer's favorite hangout place? Foo Bar!",
    "Why did the developer go broke? Because he used up all his cache!",
]

async def joke_handler(websocket, path):

    await websocket.send(random.choice(jokes))

    while True:
        try:
            message = await websocket.recv()

            # Check if the message is a smiley
            if message == ':)':
                await websocket.send("I'm glad you like the jokes! Here's another one.");
                await websocket.send(random.choice(jokes))
            else:
                await websocket.send("I don't understand what you mean. Send me a  :) for another joke.")
        except websockets.exceptions.ConnectionClosed:
            print("Connection closed")
            break


start_server = websockets.serve(joke_handler, "0.0.0.0", 8080)



asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()
