#!/usr/bin/env python3
from base64 import b64encode
from datetime import date, timedelta
from random import seed, randint
from re import findall
from sys import maxsize

NG_VERSION = '{{NGVERSION}}'
NG_SEED = '{{NGSEED}}'
NGG_VERSION = '{{NGGVERSION}}'


# noinspection PyBroadException
def main():
    again = 'Y'
    answer = get_answer()

    print(f'Number Guesser {NG_VERSION} (g.v{NGG_VERSION})')
    while again.strip().upper() == 'Y':
        guess_s = input('Guess a number: ')

        try:
            guess = int(guess_s)

            if answer == guess:
                print(f'Congratulations! {answer} was the answer! YOU WIN!')
                again = 'N'
            else:
                again = input(f'Sorry, {guess} is not the answer. Would you like to try again? (Y/N) ')
        except:
            pass


# noinspection PyBroadException
def get_answer():
    the_seed = int(NG_SEED)

    # Seed the PRNG
    seed(the_seed)

    try:
        # Do some mathy math utilizing the seed
        d = date(1970, 1, 1)
        d += timedelta(days=the_seed)
        b = bytearray()
        b.extend(map(ord, d.isoformat()))
        e = b64encode(b)
        e_s = ''.join(str(b) for b in map(chr, e))

        # Strip out non-numerics from `e_s`
        num_list = findall(r'\d+', e_s)
        num = int(''.join(str(n) for n in num_list))

        # Find our answer
        return randint(1, num)
    except:
        return randint(1, maxsize - 1)


if __name__ == '__main__':
    main()
