# how our level looks
# we will use that to place actual tiles
level_layout = [
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX',
    'X                                    X',
    'X                                    X',
    'X                                M   X',
    'X                           XXXXXXXXXX',
    'X                                    X',
    'X                  XXXX              X',
    'X                                    X',
    'X        XXXX                        X',
    'X   P                                X',
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX',
]

level_layout1 = [
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX',
    'X                                    X',
    'X   P               XXXX       X     X',
    'XXXXXXXXXX                     X     X',
    'XXXXXXXXXXX                    X     X',
    'XXXXXXXXXXXX                   X     X',
    'X         XXXXXXXXXXXXXXXXXXXXXX     X',
    'X  XXXXX                             X',
    'X  X    XX                  X        X',
    'X       MX     X            X        X',
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX',
]

level_layout2 = [
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX',
    'X                                   MX',
    'X              XXXXXXXXXXXXXXXXXXXXXXX',
    'X             X                      X',
    'X     XXX                            X',
    'X      X        X                    X',
    'X      X        X                    X',
    'X      X       XX                    X',
    'X      X        X   X   X    X       X',
    'X      X        X   X   X    X    P  X',
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX',
]
tile_size = 32
levels = [level_layout,level_layout1,level_layout2]

# user settings and preferences
screen_height = 1200
screen_width = len(level_layout) * tile_size