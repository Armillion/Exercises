from os import walk, path
import pygame

# imports all pictures from provided folder
def importFolder(fpath):
    surfaces = []
    for _,__,files in walk(fpath):
        for image in files:
            fullPath = path.join(fpath,image)
            imageSur = pygame.image.load(fullPath).convert_alpha()
            surfaces.append(imageSur)
            
    return surfaces            
