import pygame
from tile import Block
from settings import tile_size,levels
from player import Player


# represents one level in the game
# its layout, sprites and more
class Map():
    def __init__(self,data,surface,lvlNr):
        self.display_surface = surface
        self.setup(data)
        self.currentX = 0
        self.currentLevel = lvlNr
        
    # builds level from string
    def setup(self,data):
        self.blocks = pygame.sprite.Group()
        self.player = pygame.sprite.GroupSingle()
        
        for row_index, row in enumerate(data):
            for column_index, column in enumerate(row):
                if column == 'X':
                    block = Block((column_index * tile_size,row_index * tile_size),tile_size)
                    self.blocks.add(block)
                if column == 'P':
                    player_sprite = Player((column_index * tile_size,row_index * tile_size))
                    self.player.add(player_sprite)
                if column == 'M':
                    block = Block((column_index * tile_size,row_index * tile_size),tile_size)
                    block.meta = True
                    self.blocks.add(block)
    
    def horizontalMovement(self):
        player = self.player.sprite
        
        player.rect.x += player.direction.x * player.speed     
        
        for sprite in self.blocks.sprites():
            if sprite.rect.colliderect(player.rect):
                if sprite.meta:
                    self.currentLevel += 1
                    if(self.currentLevel >= len(levels)):
                        self.currentLevel = 0
                        
                    self.setup(levels[self.currentLevel])
                
                if player.direction.x < 0:
                    player.rect.left = sprite.rect.right
                    player.onLeft = True
                    self.currentX = player.rect.left
                elif player.direction.x > 0:
                    player.rect.right = sprite.rect.left
                    player.onRight = True
                    self.currentX = player.rect.right
                    
        if player.onLeft and (player.rect.left < self.currentX or player.direction.x >= 0):
            player.onLeft = False
        if player.onRight and (player.rect.right > self.currentX or player.direction.x <= 0):
            player.onRight = False
    
    def verticalMovement(self):
        player = self.player.sprite
        
        player.applyGravity()
        player.rect.y += player.direction.y
        
        for sprite in self.blocks.sprites():
            if sprite.rect.colliderect(player.rect):
                if player.direction.y > 0:
                    player.rect.bottom = sprite.rect.top
                    player.direction.y = 0
                    player.Grounded = True
                elif player.direction.y < 0:
                    player.rect.top = sprite.rect.bottom
                    player.direction.y = 0
                    player.onCeiling = True
                    
        if player.Grounded and player.direction.y < 0 or player.direction.y > 1:
            player.Grounded = False
        if player.onCeiling and player.direction.y > 0:
            player.onCeiling = False
    
    # displays level
    def update(self):
        self.blocks.update(0)
        self.blocks.draw(self.display_surface)
        
        self.player.update()
        self.horizontalMovement()
        self.verticalMovement()
        self.player.draw(self.display_surface)
        