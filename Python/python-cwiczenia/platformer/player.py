import pygame
from os import path
from support import importFolder

class Player(pygame.sprite.Sprite):
    def __init__(self,pos):
        super().__init__()
        self.impoerCharacterGraphics()
        self.frameID = 0
        self.animSpeed = 0.2
        self.image = self.animations['idle'][self.frameID]    
        self.rect = self.image.get_rect(topleft = pos)
        
        #movemnt
        self.direction = pygame.math.Vector2(0,0)
        self.speed = 5
        self.gravity = 0.75
        self.jumpForce = -15
        self.facingRight = True
        self.Grounded = False
        self.onCeiling = False
        self.onLeft = False
        self.onRight = False
        
    # import animation frames
    def impoerCharacterGraphics(self):
        # spritePath = path.join('platformer','graphics','01-KingHuman')
        spritePath = path.join('graphics','01-KingHuman')
        self.animations = {'idle':[],'run':[],'jump':[],'fall':[]}
        
        for animation in self.animations.keys():
            fpath = path.join(spritePath,animation)
            self.animations[animation] = importFolder(fpath)
         
    # decides what animations to play
    # plays set animation
    def runAnimation(self):
        if(self.direction.y > 0.8):
            animation = self.animations['fall']
        elif(self.direction.y < 0):
            animation = self.animations['jump']
        elif(self.direction.x != 0):
            animation = self.animations['run']
        else:
            animation = self.animations['idle']
        
        self.frameID += self.animSpeed
        if self.frameID >= len(animation):
            self.frameID = 0
        
        image = animation[int(self.frameID)]
        if self.facingRight:
            self.image = image
        else:
            self.image = pygame.transform.flip(image,True,False)   
            
        if self.Grounded and self.onRight:
            self.rect = self.image.get_rect(bottomright=self.rect.bottomright)
        elif self.Grounded and self.onLeft:
            self.rect = self.image.get_rect(bottomleft=self.rect.bottomleft)
        elif self.Grounded:
            self.rect = self.image.get_rect(midbottom=self.rect.midbottom)
        elif self.onCeiling and self.onRight:
            self.rect = self.image.get_rect(topright=self.rect.topright)
        elif self.Grounded and self.onLeft:
            self.rect = self.image.get_rect(topleft=self.rect.topleft)
        elif self.onCeiling:
            self.rect = self.image.get_rect(midtop=self.rect.midtop)
        else:
            self.rect = self.image.get_rect(center=self.rect.center)
            
    def getInput(self):
        keys = pygame.key.get_pressed()
        
        if(keys[pygame.K_RIGHT]):
            self.direction.x = 1
            self.facingRight = True
        elif(keys[pygame.K_LEFT]):
            self.direction.x = -1
            self.facingRight = False
        else:
            self.direction.x = 0
            
        if(keys[pygame.K_SPACE]):
            self.jump()
            
    def applyGravity(self):
        self.direction.y += self.gravity
        
    def jump(self):
        if self.Grounded:
                self.direction.y = self.jumpForce
            
    # updates input and animation frames
    def update(self):
        self.getInput()
        self.runAnimation()
        