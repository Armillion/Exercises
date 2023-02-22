# how our levels look
# we will use that to place actual blocks
# X = block
# P = player character
# M = finish line
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
screen_height = len(level_layout[0]) * tile_size
screen_width = len(level_layout) * tile_size