import pygame
from os import path
from support import importFolder

# levels consist of blocks
class Block(pygame.sprite.Sprite):
    def __init__(self, pos, size):
        super().__init__()
        self.image = pygame.Surface((size,size))
        self.importGraphics()
        self.image = self.graphics[0]
        self.rect = self.image.get_rect(topleft = pos)
        
        self.meta = False
        
    # imports sprites
    def importGraphics(self):
        # spritePath = path.join('platformer','graphics','14-TileSets')
        spritePath = path.join('graphics','14-TileSets')
        self.graphics = importFolder(spritePath) 
        
    # updates blocks position
    # paints finish red
    def update(self, x_shift):
        if(self.meta):
            self.image.fill('red')
        
        self.rect.x += x_shift
        