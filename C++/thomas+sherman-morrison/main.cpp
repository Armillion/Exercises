#include <cmath>
#include <iostream>
#define N 7

using namespace std;


int main(int argc, char **argv)
{
    float matrix[N][N] =
    {
        {4,1,0,0,0,0,0},
        {1,4,1,0,0,0,0},
        {0,1,4,1,0,0,0},
        {0,0,1,4,1,0,0},
        {0,0,0,1,4,1,0},
        {0,0,0,0,1,4,1},
        {0,0,0,0,0,1,4}
    };
    float vec[N] =
    {
        1,
        2,
        3,
        4,
        5,
        6,
        7
    };

    float betas[N-1],gammas[N];
    betas[0] = -(matrix[0][1])/(matrix[0][0]);
    gammas[0] = (vec[0])/(matrix[0][0]);

    for( int i = 1; i < N-1 ; i++)
    {
        betas[i] = -(matrix[i][i+1])/(matrix[i][i-1]*betas[i-1]+matrix[i][i]);
    }

    for( int i = 1; i < N ; i++)
    {
        gammas[i] = (vec[i] - matrix[i][i-1]*gammas[i-1])/(matrix[i][i-1]*betas[i-1]+matrix[i][i]);
    }

    float resoults[N];
    resoults[N-1] = gammas[N-1];

    for(int i = N-2 ; i >= 0; i--)
    {
        resoults[i] = betas[i]*resoults[i+1] + gammas[i];
    }

    for(auto i : resoults)
    {
        cout << i << endl;
    }
    cout << endl;

    float matrix2[N][N] =
    {
        {4,1,0,0,0,0,1},
        {1,4,1,0,0,0,0},
        {0,1,4,1,0,0,0},
        {0,0,1,4,1,0,0},
        {0,0,0,1,4,1,0},
        {0,0,0,0,1,4,1},
        {1,0,0,0,0,1,4}
    };
    float vec2[N] =
    {
        1,
        2,
        3,
        4,
        5,
        6,
        7
    };

    float u[N] = {1,0,0,0,0,0,1};
    float v[N] = {1,0,0,0,0,0,1};
    float uvT[N][N];

    for( int i = 0; i < N ; i++)
    {
        for( int j = 0; j < N ; j++)
        {
            uvT[i][j] = u[i] * v[j];
            matrix2[i][j] -= uvT[i][j];
        }
    }

    float betas2[N-1],gammas2[N];
    betas2[0] = -(matrix2[0][1])/(matrix2[0][0]);
    gammas2[0] = (vec2[0])/(matrix2[0][0]);

    for( int i = 1; i < N-1 ; i++)
    {
        betas2[i] = -(matrix2[i][i+1])/(matrix2[i][i-1]*betas2[i-1]+matrix2[i][i]);
    }

    for( int i = 1; i < N ; i++)
    {
        gammas2[i] = (vec2[i] - matrix2[i][i-1]*gammas2[i-1])/(matrix2[i][i-1]*betas2[i-1]+matrix2[i][i]);
    }

    float resoults2[N];
    resoults2[N-1] = gammas2[N-1];

    for(int i = N-2 ; i >= 0; i--)
    {
        resoults2[i] = betas2[i]*resoults2[i+1] + gammas2[i];
    }

    for(auto i : resoults2)
    {
        cout << i << endl;
    }

    return 0;
}
