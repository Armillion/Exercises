from os import walk
import pygame

def importFolder(path):
    surfaces = []
    for _,__,files in walk(path):
        for image in files:
            fullPath = path + '/' + image
            imageSur = pygame.image.load(fullPath).convert_alpha()
            surfaces.append(imageSur)
    return surfaces            

    