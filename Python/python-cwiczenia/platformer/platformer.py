import pygame
import sys
from settings import *
from tile import Block
from level import Map
from support import importFolder


# pygame init
pygame.init()
screen = pygame.display.set_mode((screen_height,screen_width))
clock = pygame.time.Clock()

# level init
level = Map(levels[0],screen,0)

# background image
bg_img = pygame.image.load('platformer\\graphics\\background.png')
bg_img = pygame.transform.scale(bg_img,(screen_height,screen_width))
rect = bg_img.get_rect()

# main loop
while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            sys.exit()
    
    screen.blit(bg_img,rect)
    level.update()
    
    pygame.display.update()
    clock.tick(60)