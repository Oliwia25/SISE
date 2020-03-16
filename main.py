from pynput import keyboard
from Board import Board

board = Board()


def main():
    board.open('BoardExample')
    board.write('test.txt')
    with keyboard.Listener(
            on_press=on_press,
            on_release=on_release) as listener:
        listener.join()


def on_press(key):
    print("hello")


def on_release(key):
    print('{0} released'.format(key))
    if key == keyboard.Key.esc:  # stop listener
        return False
    elif key == keyboard.Key.up:
        print("up")
    elif key == keyboard.Key.right:
        print("right")
    elif key == keyboard.Key.left:
        print("left")
    elif key == keyboard.Key.down:
        print("down")


if __name__ == "__main__":
    main()
